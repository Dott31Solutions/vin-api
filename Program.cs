using VinApi31;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container

builder.Host.UseAutofac();
await builder.AddApplicationAsync<AppModule>();

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline
// app.UseHttpsRedirection();
#endregion

await app.InitializeApplicationAsync(); 
app.Run();

