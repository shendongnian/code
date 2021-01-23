    foreach (BoundingBrick brick in bricks.ToArray())
        {                       
             if (ball.rect.Intersects(brick.rect))
             {
                ball.CollideEffect();
                brick.TakeDamage();
             } 
        }
