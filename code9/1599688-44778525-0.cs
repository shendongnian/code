    public static class TextureExtension
    {
        /// <summary>
        /// Creates a new texture from an area of the texture.
        /// </summary>
        /// <param name="graphics">The current GraphicsDevice</param>
        /// <param name="rect">The dimension you want to have</param>
        /// <returns>The partial Texture.</returns>
        public static Texture2D CreateTexture(this Texture2D src, GraphicsDevice graphics, Rectangle rect)
        {
            Texture2D tex = new Texture2D(graphics, rect.Width, rect.Height);
            int count = rect.Width * rect.Height;
            Color[] data = new Color[count];
            src.GetData(0, rect, data, 0, count);
            tex.SetData(data);
            return tex;
        }
    }
