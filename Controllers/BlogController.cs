using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogMoto.Models;

namespace BlogMoto.Controllers
{
    public class BlogController : Controller
    {
        BlogDBContext _db = new BlogDBContext();

        // Get all the available blog
        public ActionResult Index()
        {
            ViewBag.CurrentDateTime = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Blog blog)
        {
            if (ModelState.IsValid)
            {

                _db.Blogs.Add(blog); // Add the blog in the database

                _db.SaveChanges(); // Save the changes in the database

                ViewBag.CurrentDateTime = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

                return RedirectToAction("Index");
            }

            return View(blog);
        }

        public ActionResult Create()
        {
            ViewBag.CurrentTime = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ListOfEmployee()
        {
            var list_of_blog = _db.Blogs.Where(x => x.active == true).OrderBy(x => x.blogId);

            return PartialView(list_of_blog);
        }

        // Viewing the details of blog.
        public ActionResult Details(int id)
        {
            var blog_list = _db.Blogs.Find(id);

            return View(blog_list);
        }

        // Function for edit
        public ActionResult Edit(int id)
        {
            var blog = _db.Blogs.Find(id);

            ViewBag.CurrentTime = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

            return View(blog);
        }

        // Override the method of edit when submitted
        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(blog).State = EntityState.Modified;

                _db.SaveChanges();

                ViewBag.CurrentTime = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // Function for delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var blog_details = _db.Blogs.Find(id);
            return View(blog_details);
        }

        // Delete (Update only the active column and set to 0)
        [HttpPost]
        public ActionResult Delete(int blogId, bool active = false)
        {
            var update_blog = _db.Blogs.Where(x => x.blogId == blogId).First();

            // Set the blog column active to false
            update_blog.active = active;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
