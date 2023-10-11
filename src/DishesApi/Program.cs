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

//builder.Services.AddAuthentication().AddJwtBearer( options => {options.}); //we could configure this inline doing an action, but it's cleaner to use a settings file
builder.Services.AddAuthentication().AddJwtBearer(); 
builder.Services.AddAuthorization();
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequireAdminFromBelgium", policy => 
    policy
        .RequireRole("admin")
        .RequireClaim("country", "Belgium"));


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

app.UseAuthentication(); //this isn't strictly necessiary anymore, it gets automatically added by AddAuthN above, but adding it here gives us control of when it's added
app.UseAuthorization();  //again, not strictly necessiary, but if we are adding it, AuthZ needs to be after AuthN

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
