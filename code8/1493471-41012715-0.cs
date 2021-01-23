     public void ChangeVisibilityState(UIElement test)
        {
            if (test.Visibility == Visibility.Collapsed)
            {
                test.Visibility = Visibility.Visible;
            }
            else
            {
                test.Visibility = Visibility.Collapsed;
            }
        }
