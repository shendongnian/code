The problem is you're comparing the texture subrects, not the object's bounds. Projectile.logRect and Wood_Level_1.rectangle are the texture subrects, which you use for both collision detection and drawing. You need to store and update the current positions of each object so you can check their bounds in the world.
    class Projectile
    {
        // Removed 'static' and renamed from 'log' and 'logRect', as static limits
        // instancing and a class called "Projectile" shouldn't be limited to logs.
        public Texture2D texture;
        public Rectangle srcRect;
        public Vector2 position;
        // I suggest moving this to your input system. It's out of place here.
        public static int keyState; // = 0 is the default.
    
        public Projectile(Texture2D texture, Rectangle srcRect, Vector2 position)
        {
            this.texture = texture;
            this.srcRect = srcRect;
            this.position = position;
        }
        
        public void Update(GameTime gameTime)
        {
            // You use static variables where locals will suffice.
            double v = 0;
            double vx = 0, vy = 0;
            double alpha = 0;
            double t2 = 0;
            // I haven't thoroughly analyzed your math, but assuming it's correct, bounds should be computed correctly.
            if ((ISU.mouse.LeftButton == ButtonState.Pressed) && ISU.isInLevel == true)
            {
                keyState = 1;
                v = -820;
                alpha = MathHelper.ToRadians(33f);
                vx = v * Math.Cos(alpha);
                vy = v * Math.Sin(alpha);
            }
            if (keyState == 1)
            {
                position.Y = (float)(vy * t2 + g * t2 * t2 / 2) + 540 - srcRect.Height;
                position.X = (float)((vx * -1) * t2) + 60;
                t2 = t2 + gameTime.ElapsedGameTime.TotalSeconds;
            }
            // Clamp to the left of the viewport.
            if (position.X < 0) 
            {
                position.X = 0;
                keyState = 0;
            }
            // Clamp to the right of the viewport.
            var right = ISU.graphics.GraphicsDevice.Viewport.Width - srcRect.Width;
            if (position.X > right)
            {
                position.X = right;
                keyState = 0;
            }
            // Clamp to the top of the viewport.
            if (position.Y < 0) 
            {
                position.Y = 0;
                keyState = 0;
            }
            // Clamp to the bottom of the viewport.
            var bottom = ISU.graphics.GraphicsDevice.Viewport.Height - srcRect.Height;
            if (position.Y > bottom)
            {
                position.Y = bottom;
                keyState = 0;
            }
        }
    
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture, new Vector2(bounds.X, bounds.Y), srcRect, Color.White);
        }
    }
Finally, in the innermost loop of Collision_Detection:
         
    var proj = projectile_obj[p];
    var projBounds = new Rectangle(
        proj.position.X, proj.position.Y,
        proj.srcRect.Width, proj.srcRect.Height);
    if (projBounds.Intersects(level_1_blocks[i].rectangle))
    {
        //Subprogram here          
    }
I suggest renaming Wood_Level_1 to Level, so it doesn't appear limited to your first level. If you're not going to do that, at least rename it to WoodLevel1 to be consistent with .NET conventions.
