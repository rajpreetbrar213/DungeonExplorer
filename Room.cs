using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<Monster> monsters = new List<Monster>();
        private List<Item> items = new List<Item>();
        private Dictionary<string, Room> exits = new Dictionary<string, Room>();

        public Room(string description)
        {
            this.description = description;
        }

        public string GetDescription() => description;

        public void AddMonster(Monster monster) => monsters.Add(monster);
        public void RemoveMonster(Monster monster) => monsters.Remove(monster);

        public void AddItem(Item item) => items.Add(item);
        public void RemoveItem(Item item) => items.Remove(item);

        public IEnumerable<Monster> GetMonsters() => monsters;
        public IEnumerable<Item> GetItems() => items;

        public void AddExit(string direction, Room room) => exits[direction] = room;
        public Room GetExit(string direction) =>
            exits.TryGetValue(direction, out var room) ? room : null;

        // LINQ: Find strongest monster
        public Monster GetStrongestMonster() =>
            monsters.OrderByDescending(m => m.Health).FirstOrDefault();
    }
}