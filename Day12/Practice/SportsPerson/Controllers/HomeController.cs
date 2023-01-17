using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportsPerson.Models;

namespace SportsPerson.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
     public IActionResult Login()
    {
        return View();
    }
    public IActionResult Validate(string email, string password){
         Console.WriteLine("Validating User credentials.... ");
        
         if(email == "admin@gmail.com" && password=="admin@123"){
             Console.WriteLine("successfull validation of user..... ");
             Console.WriteLine("Redirecting to welcome..... ");   
            return Redirect("/players/insert");
           }
           else{
                return Redirect("/home/Login");
           }    
        return View();   
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
