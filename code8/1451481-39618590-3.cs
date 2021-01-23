        public void UpdatePostion()
        {
            // Create new position
            Position pos = new Position
            {
                l = 50,
                r = 190,
                t = -430,
                b = -480
            };
            Console.WriteLine($"Pos before change: {pos.ToString()}");
            // change top and bottom value to accommodate increment
            pos.t += -75;
            pos.b += -75;
            // Prove that they've been updated
            Console.WriteLine($"Pos after change: {pos.ToString()}");
        }
