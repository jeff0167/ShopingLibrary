using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingLibrary
{
    public class ShopingItem : IEquatable<ShopingItem>
    {
        private static int GlobalId = 0;
        public int Id { get; set; }

        private string _name;
        public string Name 
        {
            get => _name;
            set
            {
                if(value == null || value.Length < 2)
                {
                    throw new ArgumentException("Must be at least 2 char long and not null");
                }
                else
                {
                    _name = value;
                }
            }
        }

        int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if(value > 0)
                {
                    _quantity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Must have a quantity over the value of 0");
                }
            }
        }
        public string ShopName { get; set; }

        public ShopingItem()
        {

        }

        public ShopingItem(int id, string name, int quantity, string shopName)
        {
            Id = id;
           // Id = GlobalId++;
            Name = name;
            Quantity = quantity;
            ShopName = shopName;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ShopingItem);
        }

        public bool Equals(ShopingItem other)
        {
            return other != null &&
                   Id == other.Id &&
                   _name == other._name &&
                   Name == other.Name &&
                   Quantity == other.Quantity &&
                   ShopName == other.ShopName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, _name, Name, Quantity, ShopName);
        }

        public override string ToString()
        {
            return $"id: {Id}, name: {Name}, quantity: {Quantity}, shop name: {ShopName}";
        }
    }
}
