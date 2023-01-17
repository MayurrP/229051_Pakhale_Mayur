using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TFLStore.Models;
using HR;
using System.Text.Json;
using System.Text.Json.Serialization;   

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

    List<Employee> emp = new List<Employee>();

    public IActionResult Validate(string email, string password){
         Console.WriteLine("Validating User credentials.... ");
        foreach (var e in emp)
        {
         if(email == e.Email && password==e.Password){
             Console.WriteLine("successfull validation of user..... ");
             Console.WriteLine("Redirecting to welcome..... ");   
            return Redirect("/home/Welcome");
           }   
        } 
        return Redirect("/home");
        //return View();   
    }
     public IActionResult Registration()
    {
        return View();
    }
    string fileName=@"D:\Practical\dotnetPractical\DotNet\Day8\Ecommerce\Employee.json";

    public IActionResult ValidateRegistration(string fname,string lname,double contactno,string email, string password){
        Console.WriteLine("Validating User credentials.... ");
        
        emp.Add(new Employee(){FirstName=fname,LastName=lname,MobileNo=contactno,Email=email,Password=password});
            emp.ForEach(e=>Console.WriteLine(e.FirstName+"---"+e.LastName));
        try{
            var options=new JsonSerializerOptions {IncludeFields=true};
            var employeeJson=JsonSerializer.Serialize<List<Employee>>(emp,options);
            System.IO.File.AppendAllText(fileName,employeeJson);
            //System.IO.File.WriteAllText(fileName,employeeJson);

         
        
            string jsonString = System.IO.File.ReadAllText(fileName);
            List<Employee> jsonEmp = JsonSerializer.Deserialize<List<Employee>>(jsonString);
            Console.WriteLine("\n Record of Employees \n");
            foreach( Employee e in jsonEmp)
            {
                Console.WriteLine($"First Name := {e.FirstName}, Last Name :=  {e.LastName
                } Mobile No :=  {e.MobileNo} , Email :=  {e.Email}, Password :=  {e.Password}"); 
                }   
    }
   catch(Exception exp){
    Console.WriteLine(exp.Message);
    }
    finally{ }

        return Redirect("/home/Login");
        //return View();

    }
    
    public IActionResult Welcome()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


//  void JsonReading()
//     {
//         try{
//             string jsonString = File.ReadAllText(fileName);
//             List<Employee> jsonEmp = JsonSerializer.Deserialize<List<Employee>>(jsonString);
//             Console.WriteLine("\n Record of Employees \n");
//             foreach( Employee e in jsonEmp)
//             {
//                 Console.WriteLine($"First Name := {e.FirstName}, Last Name :=  {e.LastName
//                 } Mobile No :=  {e.MobileNo} , Email :=  {e.Email}, Password :=  {e.Password}"); 
//             }   
//         }
//         catch(Exception exp){
//         Console.WriteLine(exp.Message);
//     }
//     finally{ }
//     }