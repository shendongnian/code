    public class MyClass
    {
        private GraphicsDevice _graphicsDevice;
        public MyClass(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }
        public void Update(GameTime gameTime)
        {
            Vector2 playerPosition = new Vector2(_graphicsDevice.Viewport.TitleSafeArea.X, _graphicsDevice.Viewport.TitleSafeArea.Y + _graphicsDevice.Viewport.Height / 2);
        }
    }
