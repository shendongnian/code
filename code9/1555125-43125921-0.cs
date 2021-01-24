    Texture2D txr;
    Rectangle rect;
    Vector2 position;
    //Vector2 velocity;
    
    public player(Texture2D texture)
    {
    	txr = texture;
    	position = new Vector2(100, 100);
    	rect = new Rectangle(100, 100, txr.Width, txr.Height);
    }
    
    public void update(Rectangle wall, GameTime gt)
    {
    	//MoveIfPossible(gt, wall);		// the velocity vector was not set when this was being called
    
    	KeyboardState keys = Keyboard.GetState();
    
    	Vector2 velocity;  // Change this to local
    	if (keys.IsKeyDown(Keys.Up))
    		velocity = new Vector2(0, -1);
    	else if (keys.IsKeyDown(Keys.Down))
    		velocity = new Vector2(0, 1);
    	else if (keys.IsKeyDown(Keys.Left))
    		velocity = new Vector2(-1, 0);
    	else if (keys.IsKeyDown(Keys.Right))
    		velocity = new Vector2(1, 0);
    	else
    		velocity = new Vector2(0, 0);
    
    	MoveIfPossible(gt, wall, velocity);	// Pass vector as a parameter, if it's not needed elsewhere, keep it local
    	
    	rect.X = (int)position.X;
    	rect.Y = (int)position.Y;
    
    }
    
    // private void UpdatePositionBasedOnMovement(GameTime gameTime)
    // {
    	// position += velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 4;
    // }
    
    private void MoveIfPossible(GameTime gameTime, Rectangle wall, Vector2 velocity)
    {
    	Vector2 oldPosition = position;
    
    	//UpdatePositionBasedOnMovement(gameTime);			// Don't think this is adding anything with just one line of code
    	position += velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 4;
    	if (rect.Intersects(wall))
    	{
    		position = oldPosition;
    	}
    }
