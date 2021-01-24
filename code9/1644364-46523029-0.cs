	public void Refresh(int numberToHide)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var button = buttons[i * 4 + j];
                button.Content = myArray[i, j];
                button.Visibility = myArray[i, j] == numberToHide ?
                    Visibility.Hidden : Visibility.Visible;
            }
        }
    }
