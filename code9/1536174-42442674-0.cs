            int z = _random.Next(0, 10);
            int x = _random.Next(0, 20);
            int y = _random.Next(0, 30);
            if ((LargeEnemy.Left + LargeEnemy.Width) >= form1.Width)
            {
                LargeGoLeft = false;
            }
            if (LargeEnemy.Left <= 0)
            {
                LargeGoLeft = true;
            }
            if ((MediumEnemy.Left + MediumEnemy.Width) >= form1.Width)
            {
                MediumGoLeft = false;
            }
            if (MediumEnemy.Left <= 0)
            {
                MediumGoLeft = true;
            }
            if ((SmallEnemy.Left + SmallEnemy.Width) >= form1.Width)
            {
                SmallGoLeft = false;
            }
            if (SmallEnemy.Left <= 0)
            {
                SmallGoLeft = true;
            }
            if (LargeGoLeft)
            {
                LargeEnemy.Left -= z;
            }
            else {
                LargeEnemy.Left += z;
            }
            if (LargeGoLeft)
            {
                MediumEnemy.Left -= z;
            }
            else
            {
                MediumEnemy.Left += z;
            }
            if (LargeGoLeft)
            {
                SmallEnemy.Left -= z;
            }
            else
            {
                SmallEnemy.Left += z;
            }
