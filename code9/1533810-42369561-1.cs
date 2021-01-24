            private void TextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as TextBox).Text = DateTime.Now.Ticks.ToString();
            (sender as TextBox).SelectAll();
        }
