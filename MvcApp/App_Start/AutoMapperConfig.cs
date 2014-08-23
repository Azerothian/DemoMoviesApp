using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.App_Start
{
  public class AutoMapperConfig
  {
    public static void CreateMaps()
    {
      AutoMapper.Mapper.CreateMap<CreateMovieDataRequest, MoviesLibrary.MovieData>();
    }
  }
}