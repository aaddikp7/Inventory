using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Service;
using Inventory.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Web.APIControllers
{

    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;
        public ItemsController(ItemService itemService)
        {

            _itemService = itemService;
        }


        [HttpGet]
        [Route("Items")]
        public List<ItemViewModel> Get()
        {
            return _itemService.GetAllItems();
        }


        [HttpGet("{id}")]
        [Route("Items/{id}")]
        public ItemViewModel Get(int id)
        {
            return _itemService.GetItem(id);
        }


        [HttpPost]
        [Route("Items/Add")]
        public void Post([FromBody] ItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {

                _itemService.AddItem(itemViewModel);
            }
        }


        [HttpPost]
        [Route("Items/update/{id}")]
        public void Put(int id, [FromBody] ItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                _itemService.EditItem(id, itemViewModel);
            }
        }


        [HttpPost]
        [Route("Items/delete/{id}")]
        public void Delete(int id)
        {
            _itemService.DeleteItem(id);
        }
    }
}
