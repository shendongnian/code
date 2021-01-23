         MnuStripItem.MouseDown += new MouseEventHandler(mainM_MouseDown);
*********
        private void mainM_MouseDown(object sender, MouseEventArgs e)
        {
           //if (e.Button == MouseButtons.Left)
            if (e.Button == MouseButtons.Right)
            {
                cMenuS_main_it.Show(Cursor.Position);
            }
        }
