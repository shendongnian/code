    public abstract class Sprite {
        public void CheckCollisionSurrounding(Rectangle[,] collisionObjects) {
            for (int x = 0; x < collisionObjects.GetLength(0); x++)
            {
                for (int y = 0; y < collisionObjects.GetLength(1); y++)
                {
                    if (collisionObjects[x, y] != null) //saves us from possible null reference exceptions
                    {
                     //so now we iterate through every collision object so see if the sprite collides with it and call an action to it if it does collide.
                        if(PlayerCollRect.IntersectsWithTop(collisionObjects[x,y].tileCollRect)) {
                            //whatever you want to happen, but let's say you want the sprite at the position of the object when colliding with it:
                            playerPosition.y = collisionObjects[x,y].GetPosY;
                        }
                        //and so on for InteractWithBottom, -Right and -Left
                        //also keep in to account the dimensions of your own sprite which I haven't here. If the sprites hits left side of tile with it's right side, you have to add the width of the sprite to the calculation.
                    }
                }
            }
        }
    }
