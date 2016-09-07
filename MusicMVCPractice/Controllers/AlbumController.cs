using MusicMVCPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMVCPractice.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            var db = new DBModel();
            var album = db.getAlbum();
            return View(album);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Album item)
        {
            var db = new DBModel();
            db.addAlbum(item.Name, item.Title);
            return Redirect("Index");
        }
    }
}