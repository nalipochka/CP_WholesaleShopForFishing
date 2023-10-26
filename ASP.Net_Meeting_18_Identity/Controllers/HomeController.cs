using ASP.Net_Meeting_18_Identity.Data;
using ASP.Net_Meeting_18_Identity.Models;
using ASP.Net_Meeting_18_Identity.Models.ViewModels.HomeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASP.Net_Meeting_18_Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, ShopDbContext context)
        {
            _logger = logger;
            this.dbContext = context;
        }

        public async Task<IActionResult> Index(string? category)
        {
            IQueryable<Product> products =dbContext.Products.Include(t=>t.Category).Include(t=>t.Photos);
            if(category!=null)
            {
                products = products.Where(t => t.Category!.Title == category);
            }
            //automapper!!!!
            HomeIndexViewModel vM = new HomeIndexViewModel()
            {
                Products = await products.ToListAsync(),
                Category = category
            };
            return View(vM);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || dbContext.Products == null)
            {
                return NotFound();
            }

            var product = await dbContext.Products
                .Include(p => p.Category)
                .Include(t => t.Photos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}