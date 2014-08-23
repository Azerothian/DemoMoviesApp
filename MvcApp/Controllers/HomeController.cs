using MvcApp.Models;
using MvcApp.Util;
using System;
using System.Collections;
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
      ViewBag.Title = "Create New Movie";
      ViewBag.ReleaseYears = (from val in Enumerable.Range(1890, DateTime.Now.Year - 1889)
                              select new Kendo.Mvc.UI.DropDownListItem()
                              {
                                Text = val.ToString(),
                                Value = val.ToString()
                              }) as IEnumerable;
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateNew([Bind(Include = "Title,Classification,Genre,Rating,ReleaseDate,Cast")] CreateMovieDataRequest movieRequest)
    {
      if (ModelState.IsValid)
      {
        var data = AutoMapper.Mapper.Map<MoviesLibrary.MovieData>(movieRequest);
        
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