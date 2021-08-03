using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Host;
using ShoppingCart.Models;
using ShoppingCart.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCart.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ShoppdingCart : ControllerBase
    {
        /// <summary>
        /// Get bill by user id
        /// </summary>
        /// <returns></returns>
        /// <response code="404">If the user id doesn't exist</response>
        // GET api/<ShoppdingCart>/5
        [HttpGet("{userid}")]
        public ActionResult<string> Get(int userid)
        {
            return ShoppingCartService.getBill(userid);
        }

        /// <summary>
        /// Add a product in the user's shopping bascket
        /// </summary>
        /// <returns></returns>
        // POST api/<ShoppdingCart>
        [HttpPost]
        public ActionResult<UserInShopping> Post([FromBody] ShoppingProduct shoppingProduct)
        {
            return ShoppingCartService.addInShoppingCart(shoppingProduct);
        }
    }
}
