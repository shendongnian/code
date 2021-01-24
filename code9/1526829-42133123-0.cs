    private void TextBlockName_OnMouseDown(object sender, MouseButtonEventArgs e)
            {
                if (e.ClickCount == 2)
                {
                    this.TextBlockName.Visibility = Visibility.Collapsed;
                    this.TextBoxName.Visibility = Visibility.Visible;
                }
            }
        private void TextBoxName_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.TextBlockName.Visibility = Visibility.Visible;
            this.TextBoxName.Visibility = Visibility.Collapsed;
        }
