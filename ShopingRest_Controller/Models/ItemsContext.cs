using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopingLibrary;

namespace ShopingRest_Controller.Models
{
    public class ItemsContext : DbContext
    {
        public ItemsContext(DbContextOptions<ItemsContext> options) : base(options)
        {

        }

        public DbSet<ShopingItem> ShopingItem { get; set; }
    }
}
