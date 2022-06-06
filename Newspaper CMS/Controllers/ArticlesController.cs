using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newspaper_CMS.Data;
using Newspaper_CMS.Models;

namespace Newspaper_CMS.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
              return _context.Articles != null ? 
                          View(await _context.Articles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.Article_ID == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Article_ID,Article_Title,Article_Description,Writer_Name,Article_PublishDate,Article_Active,Category_Name")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Article_ID,Article_Title,Article_Description,Writer_Name,Article_PublishDate,Article_Active,Category_Name")] Article article)
        {
            if (id != article.Article_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Article_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.Article_ID == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
            }
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
          return (_context.Articles?.Any(e => e.Article_ID == id)).GetValueOrDefault();
        }

        [HttpGet]

        public async Task<IActionResult> Index(string searchTitle,string sortbydate)
        {
            ViewData["GetArticleDetails"] = searchTitle;
            ViewData["Datesorted"] = sortbydate;
            var articlequery = from x in _context.Articles select x;

            switch (sortbydate)
            {
                case "Article_PublishDate":
                    articlequery = articlequery.OrderBy(x => x.Article_PublishDate);
                    break;
              


            }

            if (!String.IsNullOrEmpty(searchTitle))
            {
                articlequery = articlequery.Where(x => x.Article_Title == searchTitle || x.Writer_Name == searchTitle || x.Category_Name == searchTitle);
            }
            
            //categoryquery=categoryquery.Where(x => x.Category_Name).Distinct().ToArray();
            return View(await articlequery.AsNoTracking().ToListAsync());

        }

    }
}
