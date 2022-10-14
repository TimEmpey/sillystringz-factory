using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine course)
    {
      _db.Machines.Add(course);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
        .Include(course => course.JoinEntities)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(course => course.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(course => course.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine course)
    {
      _db.Entry(course).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(course => course.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(course => course.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}