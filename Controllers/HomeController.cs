using Microsoft.AspNetCore.Mvc;
using MyServiceLibrary_Contracts;

namespace _6_aspnetcore_services_dependency_injection.Controllers;

public class HomeController : Controller
{
    private readonly ICitiesService _citiesService1;
    private readonly ICitiesService _citiesService2;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, IServiceScopeFactory serviceScopeFactory)
    {
        _citiesService1 = citiesService1;
        _citiesService2 = citiesService2;
        _serviceScopeFactory = serviceScopeFactory;
    }

    [Route("/")]
    public IActionResult Index() {
        List<string> cities = _citiesService1.GetCities();

        ViewBag.IstanceId_CitiesService_1 = _citiesService1.ServiceIstanceId;

        ViewBag.IstanceId_CitiesService_2 = _citiesService1.ServiceIstanceId;

        using (IServiceScope scope = _serviceScopeFactory.CreateScope()) { 
            ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();
            ViewBag.InstanceId_CitiesService_InScope = citiesService.ServiceIstanceId;
        }
        return View(cities);

    }
}
