namespace DungeonExplorer
{
    public abstract class Creature : IDamageable
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public abstract void TakeDamage(int amount);
        public abstract int Attack();
    }
}
