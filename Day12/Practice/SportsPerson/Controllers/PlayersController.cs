using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportsPerson.Models;
using BOL;
using BLL;

namespace SportsPerson.Controllers;

public class PlayersController : Controller
{
    private readonly ILogger<PlayersController> _logger;

    public PlayersController(ILogger<PlayersController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        SportManager mgr=new SportManager();
        List<Player> players=mgr.GetAllPlayers();
        this.ViewData["players"]=players;
        return View();
    }

    public IActionResult Details(int id)
    {
        SportManager mgr=new SportManager();
        Player players = mgr.GetPlayerById(id);
        this.ViewData["player"]=players;
        return View();
    }
    public IActionResult Insert(){
        Player player=new Player();
        return View(player);
    }

    [HttpPost]
    public IActionResult Insert( Player plays){
        if(!ModelState.IsValid){
          return View();
        }
        Console.WriteLine(plays.Playerid + 
                           " " +
                           plays.Name + " "+ 
                           plays.Sports + " "+
                           plays.Matches);
        SportManager mgr = new SportManager();
        bool status = mgr.Insert(plays);
        return RedirectToAction("Index");     
    }

    public IActionResult Update(){
        Player player=new Player();
        return View(player);
    }

    [HttpPost]
    public IActionResult Update( Player plays){
        if(!ModelState.IsValid){

               
          return View();

        }
        Console.WriteLine(plays.Playerid + 
                           " " +
                           plays.Name + " "+ 
                           plays.Sports + " "+
                           plays.Matches);
        SportManager mgr = new SportManager();
        bool status = mgr.Update(plays);
        return RedirectToAction("Index");     
    }

 public IActionResult Delete(){
        Player player=new Player();
        return View(player);
    }

    [HttpPost]
    public IActionResult Delete( Player plays){

        Console.WriteLine(plays.Playerid);
        SportManager mgr = new SportManager();
        bool status = mgr.Delete(plays.Playerid);
        if(status == true){
        return RedirectToAction("Index");     
        }
        else
        return View();
    }


    

}
