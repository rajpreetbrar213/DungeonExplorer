using System.Collections.Generic;
using System.Linq;
using System;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void Add(Item item) => items.Add(item);

        public void Remove(Item item) => items.Remove(item);

        public IEnumerable<Item> GetAllWeapons() =>
            items.OfType<Weapon>();

        public IEnumerable<Item> GetAllPotions() =>
            items.OfType<Potion>();

        public Item FindItemByName(string name) =>
            items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public string ListContents() =>
            string.Join(", ", items.Select(i => i.Name));
    }
}