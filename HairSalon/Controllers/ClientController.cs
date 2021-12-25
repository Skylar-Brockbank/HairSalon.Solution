using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    private readonly skylar_brockbankContext _db;
    public ClientController(skylar_brockbankContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Client> model = _db.Clients.ToList();
      return View(model);
    }
    public ActionResult Create(int id)
    {
      ViewBag.StylistDropdown = new List<SelectListItem> {};
      List<Stylist> CheckList = _db.Stylists.ToList();
      foreach(Stylist s in CheckList)
      {
        if(s.StylistId == id)
        {
          ViewBag.StylistDropdown.Add(new SelectListItem{Text = $"{s.Name}",Value=$"{s.StylistId}",Selected = true});
        }else{
          ViewBag.StylistDropdown.Add(new SelectListItem{Text = $"{s.Name}",Value=$"{s.StylistId}"});
        }

      }
      return View();
    }
    [HttpPost]
    public ActionResult Create(Client newClient)
    {
      _db.Clients.Add(newClient);
      _db.SaveChanges();
      return RedirectToAction("Details","Stylist", new {id=newClient.StylistId});
    
    }
    public ActionResult Details(int id)
    {
      Client input = _db.Clients.FirstOrDefault(client => client.ClientId==id);
      return View(input);
    }
    public ActionResult Edit(int id)
    {
      ViewBag.StylistDropdown = new List<SelectListItem> {};
      List<Stylist> CheckList = _db.Stylists.ToList();
      foreach(Stylist s in CheckList)
      {
        if(s.StylistId == id)
        {
          ViewBag.StylistDropdown.Add(new SelectListItem{Text = $"{s.Name}",Value=$"{s.StylistId}",Selected = true});
        }else{
          ViewBag.StylistDropdown.Add(new SelectListItem{Text = $"{s.Name}",Value=$"{s.StylistId}"});
        }

      }
      var input = _db.Clients.FirstOrDefault(client => client.ClientId==id);
      return View(input);
    }
    [HttpPost]
    public ActionResult Edit(Client returningC)
    {
      _db.Entry(returningC).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details","Client", new {id=returningC.ClientId});
    }
    public ActionResult Delete(int id)
    {
      ViewBag.id = id;
      var input = _db.Clients.FirstOrDefault(client => client.ClientId==id);
      return View(input);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var target = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      _db.Remove(target);
      _db.SaveChanges();
      return RedirectToAction("Details", "Stylist", new  {id = target.StylistId});
    }
  }
}