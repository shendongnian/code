     private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            string str = namesList[0];
            namesList[0] = namesList[1];
            namesList[1] = str;
            BindingExpression be = txtBlockName.GetBindingExpression(TextBlock.TextProperty);
            be.UpdateSource();
            this.IsEnabled = false;
        }
