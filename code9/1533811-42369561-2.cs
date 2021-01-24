            private void TextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as TextBox).Text = DateTime.Now.Ticks.ToString();
            if (MouseButtons == MouseButtons.Left) (sender as TextBox).SelectAll();
            else (sender as TextBox).SelectionLength = 0;
        }
