using MyServicesLibrary;
using MyServiceLibrary_Contracts;

namespace _6_aspnetcore_services_dependency_injection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.Add( new ServiceDescriptor( typeof(ICitiesService), typeof(CitiesService), ServiceLifetime.Scoped
                )
              );
            //AddTransient<ICitiesService, CitiesService>(); nuova istanza ogni volta, ogni injection nuovo obj
            //AddScoped<ICitiesService, CitiesService>(); 1 istanza x http req stessa istanza x tutto il req pipeline. X WEB API LA USANO IL 99% DELLE VOLTE
            //AddSingleton<ICitiesService, CitiesService>();  1 sola istanza per tutta l'app creata una volta sola
            
            //builder.Services.AddTransient<ICitiesService, CitiesService>();
            builder.Services.AddScoped<ICitiesService, CitiesService>();
            //builder.Services.AddSingleton<ICitiesService, CitiesService>();


            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
