        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var temp = sender as DataGridView;
            if (temp.ColumnCount > 0 && temp.RowCount > 0)
            {
                // get the first cell at (0, 0)
                var cellposition = dataGridView1.GetCellDisplayRectangle(0, 0, false);
                var xStart = cellposition.X;
                var yStart = cellposition.Y;
                var xEnd = xStart + cellposition.Width / 2;
                var yEnd = yStart + cellposition.Height;
                for (int i = yStart; i < yEnd; ++i)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(xStart, i), new Point(xEnd, i));
                }
            }
        }
