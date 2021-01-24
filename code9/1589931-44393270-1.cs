    public interface IGameObject
    {
        void OnCollision(IGameObject target);
    }
    public class Player : IGameObject
    {
        public void OnCollision(IGameObject target)
        {
             Console.WriteLine("Player collision");
        }
    }
    
    public class Projectile : IGameObject
    {
        public void OnCollision(IGameObject target)
        {
             Console.WriteLine("Projectile collision");
        }
    }
