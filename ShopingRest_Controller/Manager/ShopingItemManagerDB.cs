using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopingLibrary;
using ShopingRest_Controller.Models;

namespace ShopingRest_Controller.Manager
{
    public class ShopingItemManagerDB : IManagerDB<ShopingItem>
    {
        private readonly ItemsContext _context;

        public ShopingItemManagerDB(ItemsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ShopingItem>> GetAll()
        {
            return await _context.ShopingItem.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ShopingItem>> GetAllByName(string name)
        {
            return await _context.ShopingItem.AsNoTracking().Where(x => x.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }
        public async Task<ShopingItem> GetById(int id)
        {
            return await _context.ShopingItem.FindAsync(id);
        }

        public async Task Create(ShopingItem item)
        {
            await _context.ShopingItem.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, ShopingItem item)
        {
            item.Id = id;
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            _context.ShopingItem.Remove(GetById(id).Result);
            await _context.SaveChangesAsync();

        }
    }
}
