                // possition
            int XorY = RNG.Next(0, 2);
            if (XorY == 0) // top or bottom
            {
                int TorB = RNG.Next(0, 2);
                if (TorB == 0) // top
                {
                    position.X = RNG.Next(0, (int)screen_size.X);
                    position.Y = 0 - m_txr.Width;
                }
                else if (TorB == 1) // bottom
                {
                    position.X = RNG.Next(0, (int)screen_size.X);
                    position.Y = (int)screen_size.Y;
                }
            }
            else if (XorY == 1) // sides
            {
                int LorR = RNG.Next(0, 2);
                if (LorR == 0) // left side
                {
                    position.X = 0 - m_txr.Width;
                    position.Y = RNG.Next(0, (int)screen_size.Y);
                }
                else if (LorR == 1) // right side
                {
                    position.X = (int)screen_size.X;
                    position.Y = RNG.Next(0, (int)screen_size.Y);
                }
            }
