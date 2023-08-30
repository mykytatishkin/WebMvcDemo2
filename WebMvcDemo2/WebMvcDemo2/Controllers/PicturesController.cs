using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMvcDemo2.Data;
using WebMvcDemo2.Models;

namespace WebMvcDemo2.Controllers
{
    public class PicturesController : Controller
    {
        private readonly StudentContext _context;
        private readonly IWebHostEnvironment _env;

        //DI
        public PicturesController(StudentContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(int LibraryId)
        {
            //select * from library
            ViewBag.Libraries = await _context.Library.ToListAsync();   
            if(LibraryId > 0)
            {
                //select * from picture where libraryid = LibraryId
                ViewBag.Pictures = await _context.Picture.Where( p => p.LibraryId == LibraryId).ToListAsync();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            List<Library> libraries = await _context.Library.ToListAsync();  
            ViewBag.Libraries = libraries;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Picture picture, List<IFormFile> ImageUrl)
        { 
            if(ImageUrl == null)
            {
                return View();
            }
            List<Picture> list = new List<Picture>();
            foreach(IFormFile item in ImageUrl)
            {
                string path = Path.Combine(_env.WebRootPath, "images", item.FileName);
                Picture pic = new Picture() { LibraryId = picture.LibraryId, ImageUrl = "/images/"+ item.FileName };
                list.Add(pic);
                var stream = new FileStream(path, FileMode.Create);
                item.CopyToAsync(stream);
            }
            _context.Picture.AddRange(list);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}
