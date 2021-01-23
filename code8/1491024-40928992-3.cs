        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //       MazeSolution.Cell Cells = new MazeSolution.Cell masWall[x][y];
            int direction = -1;
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                direction = 0;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                direction = 2;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                direction = 1;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                direction = 3;
            }
            if (direction != -1 && CheckCollision(PlayerPosition, direction))
            {
                switch (direction)
                {
                    case 0:
                        PlayerPosition.Offset(0, -1);
                        break;
                    case 1:
                        PlayerPosition.Offset(-1, 0);
                        break;
                    case 2:
                        PlayerPosition.Offset(0, 1);
                        break;
                    case 3:
                        PlayerPosition.Offset(1, 0);
                        break;
                }
            }
            label1.Location = new Point(22 + PlayerPosition.X * Cell.kCellSize, 22 + PlayerPosition.Y * Cell.kCellSize);
            if (direction != -1)
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private bool CheckCollision(Point pos, int direction)
        {            
            Cell c = TheMaze.Cells[pos.X][pos.Y];
            if (c.Walls[direction] == 1)
                return false;
            else
                return true;
        }
