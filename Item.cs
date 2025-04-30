namespace DungeonExplorer
{
    public abstract class Item : ICollectible
    {
        public string Name { get; set; }
        public abstract void Use(Player player);
    }
}