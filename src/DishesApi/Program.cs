using DishesAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using DishesAPI.Extensions;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//add services to the container here
builder.Services.AddDbContext<DishesDbContext>(o => o.UseSqlite(
    builder.Configuration["ConnectionStrings:DishesDBConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddProblemDetails();

var app = builder.Build();

//configure the request pipeline here
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    // app.UseExceptionHandler( configureBuilder => {
    //     configureBuilder.Run(async context => {
    //         context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
    //         context.Response.ContentType = "text/html";
    //         await context.Response.WriteAsync("An unexpected problem occured.");
    //     });
    // });
}

app.UseHttpsRedirection();
app.RegisterDishesEndpoints();
app.RegisterIngredientsEndpoints();

//recreate & migrate the database on each run, for demo purposes
#pragma warning disable CS8602
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<DishesDbContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}
#pragma warning restore CS8602

app.Run();
