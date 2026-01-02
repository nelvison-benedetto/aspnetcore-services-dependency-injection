using Microsoft.AspNetCore.Mvc;
using MyServiceLibrary_Contracts;

namespace _6_aspnetcore_services_dependency_injection.Controllers;

public class HomeController : Controller
{
    private readonly ICitiesService _citiesService;
    public HomeController()
    {
        _citiesService = null; //... create obj how you want;
    }

    [Route("/")]
    public IActionResult Index() {
        List<string> cities = _citiesService.GetCities();
        return View(cities);
    }
}
