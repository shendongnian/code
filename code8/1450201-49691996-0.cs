        private void UpdateMarginOnWindowState()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.MainContainer.Margin = new Thickness(6);
                return;
            }
            this.MainContainer.Margin = new Thickness(0);
        }
