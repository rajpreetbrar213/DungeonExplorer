using System;

namespace DungeonExplorer
{
    public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public override void Use(Player player)
        {
            // Example: Equipping weapon, or using it in combat
            // For simplicity, just print message
            Console.WriteLine($"{player.Name} wields the {Name}.");
        }
    }
}