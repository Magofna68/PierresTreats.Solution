using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;

namespace PierresTreats.Controllers
{
  public class HomeController : Controller
  {
    private readonly PierresTreatsContext _db;
    public HomeController(PierresTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Treat> treat = _db.Treat.ToList();
      List<Flavor> flavor = _db.Flavor.ToList();
      model.Add("treat", treat);
      model.Add("flavor", flavor);
      return View(model);
    }
  }
}