using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Controllers
{
    public class PostsController : Controller
    {
        private PortfolioContext db = new PortfolioContext();
        public IActionResult Index()
        {
            List<Post> model = db.Posts.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            DateTime date = DateTime.Today;
            post.Date = date;
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var thisPost = db.Posts.FirstOrDefault(posts => posts.PostId == id);
            return View(thisPost);
        }
        public IActionResult Edit(int id)
        {
            var thisPost = db.Posts.FirstOrDefault(posts => posts.PostId == id);
            return View(thisPost);
        }
        [HttpPost]
        public IActionResult Edit(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisPost = db.Posts.FirstOrDefault(posts => posts.PostId == id);
            return View(thisPost);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DelelteConfirmed(int id)
        {
            var thisPost = db.Posts.FirstOrDefault(posts => posts.PostId == id);
            db.Posts.Remove(thisPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}