using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Util
{
  public class DataHelper
  {
    static MoviesLibrary.MovieDataSource _dataSource;
    public static MoviesLibrary.MovieDataSource DataSource
    {
      get
      {
        if (_dataSource == null)
        {
          _dataSource = new MoviesLibrary.MovieDataSource();
        }
        return _dataSource;
      }
    }
  }
}