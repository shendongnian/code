        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //       MazeSolution.Cell Cells = new MazeSolution.Cell masWall[x][y];
            Point change = Point.Empty;
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                change.Y = -2;
                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                change.Y = 2;
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                change.X = -2;
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                change.X = 2;
                return true;
            }
            if (CheckCollision(Point.Add(label1.Location, new Size(change)))
                label1.Location = Point.Add(label1.Location, new Size(change));
            return base.ProcessCmdKey(ref msg, keyData);
        }
