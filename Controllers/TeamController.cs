using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
 
namespace dotnetapp.Controllers;
 
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext context;
 
        public TeamController(ApplicationDbContext _context)
        {
            context = _context;
        }
       
        public IActionResult Index()
        {
            var data=context.Teams.ToList();
            return View(data);
        }
       
 
        public IActionResult Create() {
            return View();
        }
 
        [HttpPost]
 
        public IActionResult Create(Team t) {
                context.Teams.Add(t);
                context.SaveChanges();
                return RedirectToAction("Index");
 
            // return View();
        }
        public IActionResult Edit(int Id)
    {
        var data = context.Teams.Find(Id);
        return View(data);
    }
    [HttpPost]
    public IActionResult Edit(Team t)
    {
        // if (ModelState.IsValid)
        // {
            Team team = context.Teams.Find(t.TeamId);                                      
            team.TeamName = t.TeamName;
           
            context.SaveChanges();
            return RedirectToAction("Index");
        // }
        // return View();
    }
 
[HttpGet]
 
/*public IActionResult  Delete(int id)
{
    var result=context.Teams.Find(id);
    if(result==null)
    {
        return NotFound();
    }
 
    return View(result);
}
[HttpPost]
*/
 public IActionResult Delete(int id){
           var result=context.Teams.Find(id);
            if(result!=null){
                context.Teams.Remove(result);
                context.SaveChanges();
                  return RedirectToAction("Index");
            }
           
            return RedirectToAction("Team","Index");  
        }
 
    }
 