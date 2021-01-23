    public class Enemy
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
           x += GetMM() * GetSpeed()
        }
    
        public void Jump()
        {
            y += GetMM() * GetSpeed();
        }
        
        public abstract int GetMM()
        {
           return 1;
        }
    }
    
    public class Goomba : Enemy
    {
        public int GetMM()
        {
            return 5;
        }
    }
    
    public class Turtle: Enemy
    {
        public int GetMM()
        {
            return 5;
        }
     
    }
