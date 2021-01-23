            SolidColorBrush originalBrush;
            SolidColorBrush newBrush = new SolidColorBrush(Colors.Blue);
            private void backButton_Click(object sender, RoutedEventArgs e)
            {
                if ((SolidColorBrush)backButton.Background==newBrush)
                {
                    backButton.Background = originalBrush;
                }
                else
                {
                    originalBrush = (SolidColorBrush)backButton.Background;
                    backButton.Background = newBrush;
                   
                }
            }
