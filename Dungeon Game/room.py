class Room:
    def __init__(self, name, description, item=None):
        self.name = name
        self.description = description
        self.item = item
        self.left = None
        self.right = None

    def set_exits(self, left, right):
        """ Sets the left and right exits for the room """
        self.left = left
        self.right = right

    def pickup_item(self):
        """ Picks up the item in the room if available """
        if self.item:
            item = self.item
            self.item = None  # Remove item after picking up
            return item
        return None
