    // Moves and checks for collision on the Y-axis
    position.Y += ball.speed.Y;
    if (Hitbox().Intersects(obstacle))
    {
        position.Y -= ball.speed.Y;
        ball.speed.Y = -ball.speed.Y;
    }
    // Moves and checks for collision on the X-axis
    position.X += ball.speed.X;
    if (Hitbox().Intersects(obstacle))
    {
        position.X -= ball.speed.X;
        ball.speed.X = -ball.speed.X;
    }
