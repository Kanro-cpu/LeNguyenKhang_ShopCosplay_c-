using LeNguyenKhang_2122110497.Data;
using LeNguyenKhang_2122110497.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeNguyenKhang_2122110497.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context) { _context = context; }

        // GET: api/Product
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Select(p => new {
                    p.Id,
                    p.Name,
                    p.Slug,
                    p.Price,
                    p.StockQuantity,
                    p.Image,
                    CategoryName = p.Category != null ? p.Category.Name : "N/A",
                    BrandName = p.Brand != null ? p.Brand.Name : "N/A"
                })
                .ToList();

            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .FirstOrDefault(p => p.Id == id);

            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}