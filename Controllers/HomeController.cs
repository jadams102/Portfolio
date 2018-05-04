using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Microsoft.EntityFrameworkCore;



namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private PortfolioContext db = new PortfolioContext();
        public IActionResult Index()
        {
            var model = db.Posts.Include(post => post.Comments);
            return View(model);
        }
    }
}
