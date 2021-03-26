using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Entity
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [MaxLength(50)]
        public string ItemName { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
