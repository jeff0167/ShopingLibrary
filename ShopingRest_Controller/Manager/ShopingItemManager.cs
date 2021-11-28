using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopingLibrary;

namespace ShopingRest_Controller.Manager
{
    public class ShopingItemManager : IManager<ShopingItem>
    {
        static int globalId = 0;
        public static List<ShopingItem> ShopingItems = new List<ShopingItem>()
        {
            new ShopingItem(++globalId,"duck",1,"corner store"),
            new ShopingItem(++globalId,"pasta",4,"corner store"),
            new ShopingItem(++globalId,"pants",20,"corner store"),
            new ShopingItem(++globalId,"oats",5,"7 eleven"),
            new ShopingItem(++globalId,"katana",93,"log town"),
        };

        public IEnumerable<ShopingItem> GetAll()
        {
            return ShopingItems;
        }

        public IEnumerable<ShopingItem> GetAllByName(string name)
        {
            return ShopingItems.Where(x => x.Name.ToLower().Contains(name.ToLower()));
        }

        public ShopingItem GetById(int id)
        {
            return ShopingItems.Find(x => x.Id == id);
        }
        public void Create(ShopingItem item)
        {
            item.Id = ++globalId;
            ShopingItems.Add(item);
        }
        public void Update(int id, ShopingItem item)
        {
            ShopingItem shopingItem = GetById(id);

            shopingItem.Name = item.Name;
            shopingItem.Quantity = item.Quantity;
            shopingItem.ShopName = item.ShopName;
        }

        public void Delete(int id)
        {
            ShopingItems.Remove(GetById(id));
        }
    }
}
