var builder = WebApplication.CreateBuilder(args);

//add services to the container here

var app = builder.Build();

//configure the request pipeline here
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();
