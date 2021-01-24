    float originalYPosition = position.Y;
    int swoopDirection = 0;
    internal void Update(GameTime GameTime)
    {
        /* Same update code */
        if (swoopDirection != 0)
        {
            position.Y += swoopDirection;
            if (swoopDirection == 1 && this.BoundingBox.Bottom >= gameBoundingBox.Bottom)
            {
                swoopDirection = -1;
            }
            else if (swoopDirection == -1 && position.Y <= originalYPosition)
            {
                swoopDirection = 0;
            }
        }
    }
    internal void Swoop()
    {
        swoopDirection = 1;
    }
