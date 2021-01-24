        private readonly Size tileSize = new Size(200, 200);
        private void button1_Click(object sender, EventArgs e)
        {
            var pb = new PictureBox();
            var pt = GetEmptyCell(tileSize);
            pb.Location = pt;
            pb.Size = tileSize;
            Controls.Add(pb);
        }
        private Point GetEmptyCell(Size TileSize)
        {
            var ctrl = GetChildAtPoint(new Point(0, 0));
            if (ctrl == null && TileSize.Width < Width && TileSize.Height < Height)
                return new Point(0, 0);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    ctrl = GetChildAtPoint(new Point(x, y));
                    if (ctrl == null && x + TileSize.Width < Width && y + TileSize.Height < Height)
                        return new Point(x, y);
                }
            }
            throw new Exception("No Empty cells was found");
        }
