        private void ptbType1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox ptb = sender as PictureBox;
            LinkLabel lkl = ptb.Controls[0] as LinkLabel;
            if (!lkl.Bounds.Contains(ptb.PointToClient(Cursor.Position)))
            {
               lkl.Visible = false;
            }
        }
