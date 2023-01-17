using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EStore.Models;
using BOL;
using BLL;


namespace EStore.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        CatalogManager manager=new CatalogManager();
        List<Product> allProducts = manager.GetAllProductsFromFile();
        this.ViewData["products"]=allProducts;
        return View();
    }

    public IActionResult Details( int id)
    {
      CatalogManager manager=new CatalogManager();
      Product product=manager.GetProduct(id);
      this.ViewData["product"]=product;
      return View();
    }
}
