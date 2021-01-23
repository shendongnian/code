private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.BorderThickness = new Thickness(8);
            }
            else
            {
                this.BorderThickness = new Thickness(0);
            }
        }
