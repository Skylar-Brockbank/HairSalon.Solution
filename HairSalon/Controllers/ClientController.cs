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
  }
}