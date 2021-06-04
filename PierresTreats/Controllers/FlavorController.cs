using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierresTreats.Controllers
{
  [Authorize]
  public class FlavorController : Controller
  {

    private readonly PierresTreatsContext _db;

    public FlavorController(PierresTreatsContext db)
    {
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Flavor> model = _db.Flavor.ToList();
      return View(model);
    }
    [AllowAnonymous]
    public ActionResult Create()
    {
      return View();
    }
    //  [Authorize] 
    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavor.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavor
        .Include(flavor => flavor.JoinEntities)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [AllowAnonymous]
    public ActionResult Edit(int id)
    {
      var thisFlavor = _db.Flavor.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }
    // [Authorize]
    [HttpPost]
    public ActionResult Edit(FlavorController flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [AllowAnonymous]
    public ActionResult Delete(int id)
    {
      var thisFlavor = _db.Flavor.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }
    // [Authorize]
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavor.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Flavor.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}