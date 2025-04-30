using System;
using System.Linq;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        public Inventory Inventory { get; private set; } = new Inventory();

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public override void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }

        public override int Attack()
        {
            // For simplicity, base attack is 10, can be enhanced by weapon
            var weapon = Inventory.GetAllWeapons().FirstOrDefault();
            return weapon != null ? ((Weapon)weapon).Damage : 10;
        }

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} heals {amount} HP!");
        }

        public void PickUpItem(Item item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{Name} picked up {item.Name}.");
        }

        public string InventoryContents() => Inventory.ListContents();
    }
}