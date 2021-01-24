    Texture2D txr;
    Rectangle rect;
    Vector2 position;
    
    public player(Texture2D texture)
    {
    	txr = texture;
    	position = new Vector2(100, 100);
    	rect = new Rectangle(100, 100, txr.Width, txr.Height);
    }
    
    public void update(Rectangle wall, GameTime gt)
    {
    	KeyboardState keys = Keyboard.GetState();
    
    	Vector2 velocity;
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
    
    	Move(gt, wall, velocity);
    	
    	rect.X = (int)position.X;
    	rect.Y = (int)position.Y;
    }
    
    private void Move(GameTime gameTime, Rectangle wall, Vector2 velocity)
    {
    	Vector2 oldPosition = position;
    
    	position += velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 4;
    	if (rect.Intersects(wall))
    	{
    		position = oldPosition;
    	}
    }
