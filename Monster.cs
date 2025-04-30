using System;

namespace DungeonExplorer
{
    public class Monster : Creature
    {
        public int Strength { get; private set; }

        public Monster(string name, int health, int strength)
        {
            Name = name;
            Health = health;
            Strength = strength;
        }

        public override void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }

        public override int Attack()
        {
            // Basic attack, can be overridden for different monsters
            return Strength;
        }
    }

    // Example of static polymorphism (method overloading)
    public class Goblin : Monster
    {
        public Goblin() : base("Goblin", 20, 5) { }

        public override int Attack()
        {
            return Strength + 2; // Goblins get a small bonus
        }
    }

    public class Dragon : Monster
    {
        public Dragon() : base("Dragon", 100, 20) { }

        public override int Attack()
        {
            return Strength + 10; // Dragons are powerful
        }
    }
}