    public class Sprite : GameObjectComponent
    {
        public Texture2D texture;
        public Vector2 origin = Vector2.Zero;
        public Rectangle rect;
        public Rectangle sourceRect;
        public Color color = Color.White;
        public float rotation = 0f;
        private float layerDepth = 0f;
        public int scale = 1;
                
        public Sprite()
        {
        } 
        public void Load(string path)
        {
            texture = Setup.ContentDevice.Load<Texture2D>(path);
        }
    }
    
