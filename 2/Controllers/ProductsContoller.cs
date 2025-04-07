using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using net2_quiz2_დავით_ჭელიძეwebapi.DTOs;
using net2_quiz2_დავით_ჭელიძეwebapi.Models;

namespace net2_quiz2_დავით_ჭელიძეwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get()
        {
            var products = _context.Products.ToList();
            var productDtos = _mapper.Map<List<ProductDTO>>(products);
            return Ok(productDtos);
        }

        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}
