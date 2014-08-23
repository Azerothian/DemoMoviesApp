using MvcApp.Models;
using MvcApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Title = "Home";
      return View();
    }

    public ActionResult Assessment()
    {
      ViewBag.Title = "Assessment";
      ViewBag.Movies = Util.DataHelper.DataSource.GetAllData();
      
      return View();
    }
    public ActionResult GetCastById(int id)
    {
      var movie = DataHelper.DataSource.GetDataById(id);

      return Json(movie, JsonRequestBehavior.AllowGet);
    }

    public ActionResult CreateNew()
    {
      ViewBag.Title = "CreateNew";

      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateNew([Bind(Include = "Title,Classification,Genre,Rating,ReleaseDate,Cast")] CreateMovieDataRequest movieRequest)
    {
      if (ModelState.IsValid)
      {
        var data = AutoMapper.Mapper.DynamicMap<MoviesLibrary.MovieData>(movieRequest);

        int id = DataHelper.DataSource.Create(data);
        if(id > -1)
        {
          return RedirectToAction("Assessment");
        }


      }
      return View(movieRequest);
    }
  }
}