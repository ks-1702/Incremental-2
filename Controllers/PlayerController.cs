using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using dotnetapp.Models;
 
namespace dotnetapp.Controllers;
    public class PlayerController : Controller
    {
        private static List<Player>Players = new List<Player>{new Player{Id=1,Name="Kshitija",Age=21,Category="Fielder",BiddingAmount=29167}};
        private readonly ApplicationDbContext context;
 
        public PlayerController(ApplicationDbContext _context)
        {
            context = _context;
        }
 
     [Route("")]
    public IActionResult Index()
 
    {
        var data = context.Players.ToList();
        return View(data);
    }
 
    public IActionResult Display(int Id)
 
    {
        var data = context.Players.Find(Id);
        return View(data);
    }
 
 
    [Route("create")]
 
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
   // [Route("create")]
    public IActionResult Create(Player play)
    {

            context.Players.Add(play);
            context.SaveChanges();  
            return RedirectToAction("Index");
       
    }
    public IActionResult Edit(int Id)
    {
        var data = context.Players.Find(Id);
        return View(data);
    }
    [HttpPost]
    public IActionResult Edit(Player play)
    {
       
            Player player = context.Players.Find(play.Id);                                      
            player.Name = play.Name;
            player.Age = play.Age;
            player.Category = play.Category;
            player.BiddingAmount=play.BiddingAmount;
           
            context.SaveChanges();
            return RedirectToAction("Index");
    }
 
   public IActionResult Delete(int id)
        {
            var data = context.Players.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Player p)
        {
                Player player=context.Players.Find(p.Id);
                context.Players.Remove(player);
                context.SaveChanges();
                return RedirectToAction("Index");
        }

// public IActionResult Delete(int id)
//         {
//             var data = context.Players.Find(id);
//             return View(data);
//         }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
                var ps = context.Players.Find(id);
                context.Players.Remove(ps);
                context.SaveChanges();
                return RedirectToAction("Index");
        }
 
 
    }
 

   

 
    