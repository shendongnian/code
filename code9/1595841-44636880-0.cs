    static void move()
        {
            if (Game1.currentKeyboardState.IsKeyDown(Keys.D))
            {
                bool isColliding = false;
                foreach (tile Tile in gameWorld.tileArray)
                {
                    if (currentCharacterRectangle.Right >= Tile.currentRectangle.Left && currentCharacterRectangle.Left < Tile.currentRectangle.Right && currentCharacterRectangle.Top < Tile.currentRectangle.Bottom && currentCharacterRectangle.Bottom > Tile.currentRectangle.Top && Tile.isSolid)
                    {
                        isColliding = true;
                    }
                }
                if (!isColliding)
                {
                    currentCharacterRectangle.X += walkingSpeed;
                }
            }
            if (Game1.currentKeyboardState.IsKeyDown(Keys.D) && Game1.currentKeyboardState.IsKeyDown(Keys.LeftShift))
            {
                currentCharacterRectangle.X += runningSpeed;
            }
            if (Game1.currentKeyboardState.IsKeyDown(Keys.Q))
            {
                bool isColliding = false;
                foreach (tile Tile in gameWorld.tileArray)
                {
                    if (currentCharacterRectangle.Left <= Tile.currentRectangle.Right && currentCharacterRectangle.Right > Tile.currentRectangle.Left && currentCharacterRectangle.Top < Tile.currentRectangle.Bottom && currentCharacterRectangle.Bottom > Tile.currentRectangle.Top && Tile.isSolid)
                    {
                        isColliding = true;
                    }
                }
                if (!isColliding)
                {
                    currentCharacterRectangle.X -= walkingSpeed;
                }
            }
            if (Game1.currentKeyboardState.IsKeyDown(Keys.Q) && Game1.currentKeyboardState.IsKeyDown(Keys.LeftShift))
            {
                currentCharacterRectangle.X -= runningSpeed;
            }
            if (Game1.currentKeyboardState.IsKeyDown(Keys.S))
            {
                bool isColliding = false;
                foreach (tile Tile in gameWorld.tileArray)
                {
                    if (currentCharacterRectangle.Bottom >= Tile.currentRectangle.Top && currentCharacterRectangle.Top < Tile.currentRectangle.Bottom && currentCharacterRectangle.Right > Tile.currentRectangle.Left && currentCharacterRectangle.Left < Tile.currentRectangle.Right && Tile.isSolid)
                    {
                        isColliding = true;
                    }
                }
                if (!isColliding)
                {
                    currentCharacterRectangle.Y++;
                }
            }
            if (Game1.currentKeyboardState.IsKeyDown(Keys.Z))
            {
                bool isColliding = false;
                foreach (tile Tile in gameWorld.tileArray)
                {
                    if (currentCharacterRectangle.Top <= Tile.currentRectangle.Bottom && currentCharacterRectangle.Top > Tile.currentRectangle.Top && currentCharacterRectangle.Right > Tile.currentRectangle.Left && currentCharacterRectangle.Left < Tile.currentRectangle.Right && Tile.isSolid)
                    {
                        isColliding = true;
                    }
                }
                if (!isColliding)
                {
                    currentCharacterRectangle.Y--;
                }
            }
        }
