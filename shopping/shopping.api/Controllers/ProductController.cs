using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using shopping.api.Models;
using shopping.client.NewFolder;


namespace shopping.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductContext context, ILogger<ProductController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        }
    }
}

