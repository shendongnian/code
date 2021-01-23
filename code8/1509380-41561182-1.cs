     if (!toggle)
            {
                x = (SolidColorBrush)backButton.Background;
                backButton.Background = new SolidColorBrush(Colors.Blue);
                toggle = true;
            }
            else
            {
                backButton.Background = x;
                toggle = false;
            }
