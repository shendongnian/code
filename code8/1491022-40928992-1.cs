        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //       MazeSolution.Cell Cells = new MazeSolution.Cell masWall[x][y];
            Point change = Point.Empty;
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                change.Y = -2;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                change.Y = 2;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                change.X = -2;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                change.X = 2;
            }
            
            // Check if player's new position will collide with wall
            if (CheckCollision(Point.Add(label1.Location, new Size(change)))
                label1.Location = Point.Add(label1.Location, new Size(change));
            // If key was pressed to move character, handle the key press
            if (change != Point.Empty)
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }
