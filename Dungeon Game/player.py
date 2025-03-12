class Player:
    def __init__(self, name, health):
        self.name = name
        self.health = health
        self.inventory = []

    def add_to_inventory(self, item):
        """ Adds an item to the player's inventory """
        self.inventory.append(item)

    def get_inventory(self):
        """ Returns the inventory as a string """
        return ", ".join(self.inventory) if self.inventory else "Empty"
