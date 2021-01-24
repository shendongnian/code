            private void cbb_main_Click(object sender, EventArgs e)
        {
            cbb_2.Location = new Point(cbb_main.Location.X, cbb_main.Location.Y - cbb_2.Size.Height - (cbb_2.ItemHeight *cbb_2.Items.Count));
            cbb_main.DroppedDown = false;
            cbb_2.DroppedDown = true;
        }
