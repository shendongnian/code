        private void button_Click(object sender, RoutedEventArgs e)
        {
            Update(Brushes.White, textBox);
            if (textBox.Text == "N") NotCorrect();
        }
        
        private void NotCorrect()
        {
            Update(textblock.background, null);
            textBlock.text = "Try again..."
        }
        
        private void Update(Brushes myBrush, Control myControl)
        {
            texBlock.Background = myBrush;
            if (myControl != null)
                myControl.Focus();
        }
