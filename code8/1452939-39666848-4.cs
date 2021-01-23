    public abstract class Enemy
    {
        public float x;
        public float y;
    
        private float speed;
    
        public float GetSpeed()
        {
            return speed;
        }
    
        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }
        
        public void Move()
        {
            x += GetMovementAmount() * GetSpeed();
        }
        public abstract decimal GetMovementAmount();
    }
    
    public class Goomba : Enemy
    {
        public void GetMovementAmount()
        {
            return 5;
        }
    }
    
    public class Turtle: Enemy
    {
        public void GetMovementAmount()
        {
            return 6;
        }
    }
