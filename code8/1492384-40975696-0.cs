    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    namespace YourGameProject
    {
        public class Sprite
        {
            public string AssetName { get; set; }
            public void Load(ContentManager content)
            {
                content.Load<Texture2D>(AssetName);
            }
        }
    }
