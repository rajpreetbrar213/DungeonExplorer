using System;

namespace DungeonExplorer
{
    public class Potion : Item
    {
        public int HealAmount { get; set; }

        public Potion(string name, int healAmount)
        {
            Name = name;
            HealAmount = healAmount;
        }

        public override void Use(Player player)
        {
            player.Heal(HealAmount);
            Console.WriteLine($"{player.Name} drinks {Name} and heals {HealAmount} HP!");
        }
    }
}