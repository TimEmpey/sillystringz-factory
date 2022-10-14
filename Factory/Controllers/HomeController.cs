using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;

namespace Factory.Controllers
{
    public class HomeController : Controller
    {

    private readonly FactoryContext _db;

    public HomeController(FactoryContext db)
    {
      _db = db;
    }

      [HttpGet("/")]
      public ActionResult Index()
      {
        ViewBag.Machine = new List<Machine>(_db.Machines);
        ViewBag.Engineer = new List<Engineer>(_db.Engineers);
        return View(ViewBag.Machine);
      }

    }
}