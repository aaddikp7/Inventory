using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inventory.ViewModel
{
    public class ItemViewModel
    {
        [Key]
        public int ItemId { get; set; }

        [MaxLength(50)]
        [Required]
        public string ItemName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
