using System.Collections.Generic;

namespace DungeonExplorer
{
    public class GameMap
    {
        private Dictionary<string, Room> rooms = new Dictionary<string, Room>();
        public Room StartingRoom { get; private set; }

        public GameMap()
        {
            // Example: create rooms and connect them
            var room1 = new Room("Entrance Hall");
            var room2 = new Room("Dark Corridor");
            var room3 = new Room("Treasure Chamber");

            room1.AddExit("north", room2);
            room2.AddExit("south", room1);
            room2.AddExit("east", room3);
            room3.AddExit("west", room2);

            rooms.Add("Entrance Hall", room1);
            rooms.Add("Dark Corridor", room2);
            rooms.Add("Treasure Chamber", room3);

            StartingRoom = room1;
        }

        public Room GetRoom(string description) =>
            rooms.TryGetValue(description, out var room) ? room : null;
    }
}