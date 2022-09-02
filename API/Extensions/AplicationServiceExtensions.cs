

using Core.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;

namespace API.Extensions;

public static class AplicationServiceExtensions
{
    //IServiceCollection ---> REVISA EL TIPO DE DATO
    public static void ConfigureCors(this IServiceCollection services) =>
        // PERMITE ACCESO DESDE CUALQUIER ORIGEN, CUALQUIER MÉTODO Y CUALQUIER ENCABEZADO
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                                              // SE USAN CUANDO EL API SALE A PRODUCCIÓN
                    builder.AllowAnyOrigin()  //WithOrigins("https://dominio.com") recibe dominios ya definidos
                    .AllowAnyMethod()         //WithMethods("GET","POST")
                    .AllowAnyHeader());       //WithMethods("accept","content-type")
        });
    //DECLARA UN METODO DONDE LLAMA LOS REPOSITORIOS
    public static void AddAplicacionServices(this IServiceCollection services)
    {
        //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //services.AddScoped<IProductoRepository, ProductoRepository>();
        //services.AddScoped<IMarcaRepository, MarcaRepository>();
        //services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
