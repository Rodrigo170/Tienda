using API.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.AddAplicacionServices();

builder.Services.AddControllers();

builder.Services.AddDbContext<TiendaContext>(options =>
{
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 12));
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<TiendaContext>();
        await context.Database.MigrateAsync();
        await TiendaContextSeed.SeedAsync(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Ocurri� un error durante la migraci�n");
    }
}

app.UseCors("CorsPolicy"); //PARA EJECUTAR CORS

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
