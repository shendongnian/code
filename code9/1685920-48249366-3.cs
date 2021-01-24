    private void DrawGrid(Graphics g)
        {
            Pen p = new Pen(new HatchBrush(HatchStyle.LargeGrid | HatchStyle.Percent50, Color.LightGray, Color.Transparent), 1);
            for (int i = 0; i < this.Size.Width; i+=50)
            {
                g.DrawLine(p, new Point(i, **0**), new Point(i, this.Size.Height));
            }
            for (int i = 0; i < this.Size.Height; i += 50)
            {
                g.DrawLine(p, new Point(**0**,i), new Point(this.Size.Width, i));
            }
            p.Dispose();
        }
