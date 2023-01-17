using HR;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var emp = new Employee(){Id=51,Name="Tony",Designation="IRONMAN",Salary=100000};

List<Employee> employ = new List<Employee>();

employ.Add(new Employee(){Id=52,Name="Steve",Designation="CAPTAIN AMERICA",Salary=90000});
employ.Add(new Employee(){Id=53,Name="Bruce",Designation="HULK",Salary=85000});
employ.Add(new Employee(){Id=54,Name="Natasha",Designation="BLACK WIDOW",Salary=80000});
employ.Add(new Employee(){Id=55,Name="Peter",Designation="SPIDERMAN",Salary=75000});


app.MapGet("/", () => "Hello Mayur..!");
app.MapGet("/api/home",()=>"TransFlower Store");
app.MapGet("/api/employee",()=>emp);
app.MapGet("/api/employees",()=>employ);
app.Run();
