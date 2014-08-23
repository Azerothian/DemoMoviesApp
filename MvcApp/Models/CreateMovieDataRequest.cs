using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
  public class CreateMovieDataRequest
  {
    [Required]
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Classification { get; set; }
    public int Rating { get; set; }
    public string[] Cast { get; set; }
    public int? ReleaseDate { get; set; }
  }
}