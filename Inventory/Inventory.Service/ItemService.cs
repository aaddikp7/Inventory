using Inventory.Entity;
using Inventory.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.Service
{
    public class ItemService
    {
        private readonly InventoryContext _context;
        public ItemService(InventoryContext context)
        {
            _context = context;
        }
        public List<ItemViewModel> GetAllItems()
        {
            List<Item> items = _context.Items.ToList();

            List<ItemViewModel> itemViewModels = items.Select(x => new ItemViewModel
            {
                ItemId = x.ItemId,
                ItemName = x.ItemName,
                Description = x.Description,
                Price = x.Price
            }).ToList();

            return itemViewModels;
        }

        public void AddItem(ItemViewModel authorViewModel)
        {
            Item item = new Item()
            {
                ItemName = authorViewModel.ItemName,
                Description = authorViewModel.Description,
                Price = authorViewModel.Price
            };

            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void EditItem(int id, ItemViewModel authorViewModel)
        {
            Item item = _context.Items.Where(x => x.ItemId == id).FirstOrDefault();

            item.ItemName = authorViewModel.ItemName;
            item.Description = authorViewModel.Description;
            item.Price = authorViewModel.Price;
            _context.Items.Update(item);

            _context.SaveChanges();

        }

        public ItemViewModel GetItem(int id)
        {
            Item item = _context.Items.Where(x => x.ItemId == id).FirstOrDefault();

            ItemViewModel itemViewModel = new ItemViewModel()
            {
                ItemId = item.ItemId,
                Price = item.Price,
                ItemName = item.ItemName,
                Description = item.Description
            };

            return itemViewModel;
        }

        public void DeleteItem(int id)
        {
            Item author = _context.Items.Where(x => x.ItemId == id).FirstOrDefault();

            if (author != null)
            {
                _context.Items.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
