    public asteroid(Texture2D txr, Vector2 screen_size, Random RNG)
    {
        m_txr = txr;
        position = Vector2.Zero;
        position.X = RNG.Next(0, (int)screen_size.X + 10);
        position.Y = RNG.Next(0, (int)screen_size.Y + 10);
        circle = new BoundingSphere(new Vector3(position.X + m_txr.Width / 2, position.Y + m_txr.Height / 2, 0), m_txr.Width / 2);
        velocity = new Vector2(0, 0);
        while (velocity.X == 0 || velocity.Y == 0)
            velocity = new Vector2((float)RNG.NextDouble() * RNG.Next(-2, 2), (float)RNG.NextDouble() * RNG.Next(-2, 2));
        rect = new Rectangle((int)position.X, (int)position.Y, m_txr.Width, m_txr.Height);
    }
