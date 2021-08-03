using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {

        /// <summary>
        /// Get products available
        /// </summary>
        /// <returns></returns>
        // GET: api/<Products>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Product.Instance;
        }

        /// <summary>
        /// Get product available by product code
        /// </summary>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="404">If the product code is not available</response>
        // GET api/<Products>/5
        [HttpGet("{code}")]
        public ActionResult<Product> Get(int code)
        {
            Product product = Product.Instance.Find(p => p.ProductCode.Equals(code));
            if (product == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(product);
        }
    }
}
