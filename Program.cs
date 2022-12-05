using VinApi31;

var builder = WebApplication.CreateBuilder(args);

/* START - Add services to the container */
await builder.AddApplicationAsync<AppModule>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

await app.InitializeApplicationAsync(); 
app.Run();

