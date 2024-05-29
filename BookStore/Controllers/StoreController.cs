using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Work == null)
            {
                return NotFound();
            }

            var album = await _context.Work
                .Include(a => a.Writer)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
        public async Task<ActionResult> Browse(int? id)
        {
            var gelen = _context.Work.Where(a => a.GenreId == id).ToList();

            var genres = _context.Genre.ToList();

            WorkGenreModel viewModel = new WorkGenreModel();

            viewModel.Works = gelen;
            viewModel.Genres = genres;

            return View(viewModel);
        }
    }
}
