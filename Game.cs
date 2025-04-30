using System;
using System.Linq;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private GameMap map;

        public Game()
        {
            // Initialize player and map
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            player = new Player(name, 100);

            map = new GameMap();
            currentRoom = map.StartingRoom;

            // Populate rooms with monsters and items
            var goblin = new Goblin();
            var dragon = new Dragon();
            var sword = new Weapon("Sword", 15);
            var potion = new Potion("Healing Potion", 25);

            currentRoom.AddItem(sword);
            currentRoom.AddMonster(goblin);
            var treasureRoom = map.GetRoom("Treasure Chamber");
            treasureRoom.AddMonster(dragon);
            treasureRoom.AddItem(potion);
        }

        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine($"\nYou are in {currentRoom.GetDescription()}");
                Console.WriteLine($"Health: {player.Health}");
                Console.WriteLine("Monsters here: " + string.Join(", ", currentRoom.GetMonsters().Select(m => m.Name)));
                Console.WriteLine("Items here: " + string.Join(", ", currentRoom.GetItems().Select(i => i.Name)));
                Console.WriteLine("Inventory: " + player.InventoryContents());
                Console.Write("What do you want to do? (move/use/pickup/attack/inventory/quit): ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "move":
                        Console.Write("Direction? ");
                        string dir = Console.ReadLine().ToLower();
                        var nextRoom = currentRoom.GetExit(dir);
                        if (nextRoom != null)
                        {
                            currentRoom = nextRoom;
                        }
                        else
                        {
                            Console.WriteLine("You can't go that way.");
                        }
                        break;

                    case "pickup":
                        Console.Write("Item name? ");
                        string itemName = Console.ReadLine();
                        var item = currentRoom.GetItems().FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
                        if (item != null)
                        {
                            player.PickUpItem(item);
                            currentRoom.RemoveItem(item);
                        }
                        else
                        {
                            Console.WriteLine("No such item here.");
                        }
                        break;

                    case "use":
                        Console.Write("Item name? ");
                        string useItemName = Console.ReadLine();
                        var useItem = player.Inventory.FindItemByName(useItemName);
                        if (useItem != null)
                        {
                            useItem.Use(player);
                            if (useItem is Potion) player.Inventory.Remove(useItem); // Potions are consumed
                        }
                        else
                        {
                            Console.WriteLine("You don't have that item.");
                        }
                        break;

                    case "attack":
                        if (!currentRoom.GetMonsters().Any())
                        {
                            Console.WriteLine("No monsters to attack!");
                            break;
                        }
                        var monster = currentRoom.GetStrongestMonster();
                        int damage = player.Attack();
                        monster.TakeDamage(damage);
                        Console.WriteLine($"You attack {monster.Name} for {damage} damage!");
                        if (monster.Health <= 0)
                        {
                            Console.WriteLine($"You defeated {monster.Name}!");
                            currentRoom.RemoveMonster(monster);
                        }
                        else
                        {
                            int monsterDamage = monster.Attack();
                            player.TakeDamage(monsterDamage);
                            Console.WriteLine($"{monster.Name} attacks you for {monsterDamage} damage!");
                            if (player.Health <= 0)
                            {
                                Console.WriteLine("You died! Game over.");
                                playing = false;
                            }
                        }
                        break;

                    case "inventory":
                        Console.WriteLine("Inventory: " + player.InventoryContents());
                        break;

                    case "quit":
                        playing = false;
                        Console.WriteLine("Thanks for playing!");
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
    }
}