using BlogCRUD.Data;
using System;
using BlogCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogCRUD.Controllers
{
    public class Posts : Controller
    {
        private readonly MyAppContext _context;
        public Posts(MyAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //var posts = await (from p in _context.Posts
            //                    join a in _context.Authours
            //                    on p.authorId equals a.Id
            //                    select new
            //                    {
            //                        p.Id,  
            //                        p.Title,
            //                       a.Name
            //                    }
            //                   ).ToListAsync();
            var posts = await _context.Posts.Include(p => p.Authour).ToListAsync();
            return View(posts);
        }
        public async Task<IActionResult> CreatePost()
        {
            var authors = await (from a in _context.Authours select a).ToListAsync();
            //var authors = await _context.Authours.ToListAsync();
            return View(authors);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.date = DateOnly.FromDateTime(DateTime.Now);
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(post);
        }
        public async Task<IActionResult> PostById(int id)
        {
            var post = await _context.Posts.Include(p => p.Authour).FirstOrDefaultAsync(p => p.Id == id);
            return View(post);
        }

        public async Task<IActionResult> UpdatePost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            return View(post);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.date = DateOnly.FromDateTime(DateTime.Now);
                _context.Update(post);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(post);
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if(post!= null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
