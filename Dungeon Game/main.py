import tkinter as tk
from tkinter import messagebox
from player import Player
from room import Room

class DungeonExplorer:
    def __init__(self, root):
        self.root = root
        self.root.title("Dungeon Explorer")
        self.root.geometry("500x400")

        # Initialize Player and Rooms
        self.player = Player("Hero", 100)
        self.rooms = {
            "Hall": Room("Hall", "A grand hall with old paintings and a dusty chandelier.", "Key"),
            "Dungeon": Room("Dungeon", "A dark, damp dungeon with chains on the walls.", "Sword"),
            "Treasure Room": Room("Treasure Room", "A glittering room full of gold and jewels.", "Treasure")
        }
        self.rooms["Hall"].set_exits(self.rooms["Dungeon"], self.rooms["Treasure Room"])
        self.rooms["Dungeon"].set_exits(self.rooms["Hall"], None)
        self.rooms["Treasure Room"].set_exits(None, self.rooms["Hall"])
        self.current_room = self.rooms["Hall"]

        # UI Elements
        self.label_room = tk.Label(root, text=f"📍 {self.current_room.name}", font=("Arial", 14, "bold"))
        self.label_room.pack(pady=10)

        self.label_description = tk.Label(root, text=self.current_room.description, wraplength=400, font=("Arial", 12))
        self.label_description.pack(pady=10)

        self.label_health = tk.Label(root, text=f"❤️ Health: {self.player.health}", font=("Arial", 12))
        self.label_health.pack(pady=5)

        self.label_inventory = tk.Label(root, text=f"🎒 Inventory: {self.player.get_inventory()}", font=("Arial", 12))
        self.label_inventory.pack(pady=5)

        self.button_move_left = tk.Button(root, text="⬅ Move Left", command=self.move_left)
        self.button_move_left.pack(side="left", padx=20)

        self.button_move_right = tk.Button(root, text="➡ Move Right", command=self.move_right)
        self.button_move_right.pack(side="right", padx=20)

        self.button_pickup = tk.Button(root, text="🛡 Pick Up Item", command=self.pickup_item)
        self.button_pickup.pack(pady=10)

        self.button_exit = tk.Button(root, text="🚪 Exit Game", command=root.quit)
        self.button_exit.pack(pady=10)

        self.update_ui()

    def update_ui(self):
        """ Updates the UI labels based on the current room and player state """
        self.label_room.config(text=f"📍 {self.current_room.name}")
        self.label_description.config(text=self.current_room.description)
        self.label_health.config(text=f"❤️ Health: {self.player.health}")
        self.label_inventory.config(text=f"🎒 Inventory: {self.player.get_inventory()}")

    def move_left(self):
        """ Moves player to the left room if possible """
        if self.current_room.left:
            self.current_room = self.current_room.left
            self.update_ui()
        else:
            messagebox.showwarning("❌ Can't Move", "You can't move left from here.")

    def move_right(self):
        """ Moves player to the right room if possible """
        if self.current_room.right:
            self.current_room = self.current_room.right
            self.update_ui()
        else:
            messagebox.showwarning("❌ Can't Move", "You can't move right from here.")

    def pickup_item(self):
        """ Allows the player to pick up an item in the current room """
        item = self.current_room.pickup_item()
        if item:
            self.player.add_to_inventory(item)
            messagebox.showinfo("🛡 Item Collected", f"You picked up: {item}")
        else:
            messagebox.showinfo("❌ No Items", "There's nothing to pick up here.")
        self.update_ui()

# Run the Game
if __name__ == "__main__":
    root = tk.Tk()
    game = DungeonExplorer(root)
    root.mainloop()
