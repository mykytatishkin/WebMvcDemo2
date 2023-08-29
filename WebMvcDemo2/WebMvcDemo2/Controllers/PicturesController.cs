using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebMvcDemo2.Data;
using WebMvcDemo2.Models;

namespace WebMvcDemo2.Controllers
{
    public class PicturesController : Controller
    {
        private readonly StudentContext _context;

        public PicturesController(StudentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Library> libraries = _context.Library.ToList<Library>();
            ViewBag.Library = libraries;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Picture picture, List<IFormFile> ImageUrl)
        {
            return View();
        }
    }
}
