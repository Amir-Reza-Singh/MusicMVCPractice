using MusicMVCPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMVCPractice.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            var db = new DBModel();
            var artist = db.getArtist();
            return View(artist);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Artist item) {
            var db = new DBModel();
            db.addArtist(item.Name);
            return Redirect("Index");
        }
    }
}