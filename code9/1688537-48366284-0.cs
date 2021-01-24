    int speed = 0;
    Vector2 pos;
    protected override void Update(GameTime gameTime)
    {
    	if (Keyboard.GetState().IsKeyDown(Keys.Escape))
    	{
    		Exit();
    	}
    	k = Keyboard.GetState();        // Get New States
    	m = Mouse.GetState();
        speed = 0;                      // Reset Speed
    
        if(k.IsKeyDown(Keys.D)) 
        {
            speed = 3; 
        }
        // Similar code for A (but negative)
        if(Collides(pos, rockPos)) // whatever your intersect condition is
        {
            speed = 0;
        }
        pos.x += speed;
    	base.Update(gameTime);
    }
