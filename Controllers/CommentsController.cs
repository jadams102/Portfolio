using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Controllers
{
    public class CommentsController : Controller
    {
        private PortfolioContext db = new PortfolioContext();
        public IActionResult Index()
        {
            List<Comment> model = db.Comments.ToList();
            return View(model);
        }
        public IActionResult Create(int id)
        {
            Post post = db.Posts.FirstOrDefault(posts => posts.PostId == id);
            ViewBag.PostId = post.PostId;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            db.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            Comment model = db.Comments.FirstOrDefault(comment => comment.CommentId == id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Comment thisComment = db.Comments.FirstOrDefault(comment => comment.CommentId == id);
            db.Remove(thisComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}