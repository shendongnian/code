        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            Panel pnl = sender as Panel;
            Label src = e.Data.GetData(typeof(Label)) as Label;
            src.Location = pnl.PointToClient(new Point(e.X, e.Y));
            pnl.Controls.Add(src);
        }
