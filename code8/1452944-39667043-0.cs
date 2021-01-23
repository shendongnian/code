    public class Enemy
    {
        public float x { get; private set; }
        public float y { get; private set; }
    
        private float speed;
    
        public Move(float dx, float dy)
        {
            x += dx * speed;
            y += dy * speed;
        }
    }
