using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopingLibrary;
using ShopingRest_Controller.Manager;
using Microsoft.AspNetCore.Http;
using ShopingRest_Controller.Models;

namespace ShopingRest_Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopingItemController : ControllerBase
    {
       // IManager<ShopingItem> mgr;
        IManagerDB<ShopingItem> mgr;

        public ShopingItemController(ItemsContext context)
        {
            //mgr = new ShopingItemManager();
            mgr = new ShopingItemManagerDB(context);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IEnumerable<ShopingItem> Get()
        {
            //return mgr.GetAll();
            return mgr.GetAll().Result;
        }

        // GET api/<ShopingItemController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ShopingItem Get(int id)
        {
            //return mgr.GetById(id);
            return mgr.GetById(id).Result;
        }

        [HttpGet("Name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<ShopingItem> Get(string name)// [FromQuery] puts the ? mark in the url, but it write  search?=name  and the search is mandataory though it can be whatever string and has no effect on the call
        {
            //return mgr.GetAllByName(name);
            return mgr.GetAllByName(name).Result;
        }

        // POST api/<ShopingItemController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public void Post([FromBody] ShopingItem value)
        {
            mgr.Create(value);
        }

        // PUT api/<ShopingItemController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public void Put(int id, [FromBody] ShopingItem value)
        {
            mgr.Update(id, value);
        }

        // DELETE api/<ShopingItemController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public void Delete(int id)
        {
            mgr.Delete(id);
        }
    }
}
