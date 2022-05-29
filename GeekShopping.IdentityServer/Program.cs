using GeekShopping.IdentityServer;
using GeekShopping.IdentityServer.Initializer;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
// Add services to the container.
startup.ConfigureServices(builder.Services);

var app = builder.Build();
var scope = app.Services.CreateScope();
IDBInitializer dBInitializer = scope.ServiceProvider.GetService<IDBInitializer>();

startup.Configure(app, app.Environment, dBInitializer);

// Configure the HTTP request pipeline.

