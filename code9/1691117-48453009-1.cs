       private void Paste_Click(object sender, RoutedEventArgs e)
            {
                if (sender is MenuItem menuItem)
                {
                    Debug.WriteLine("Ok");
                }
        
                if (e.OriginalSource is MenuItem menuItem2)
                {
                    Debug.WriteLine("Ok");
                }
            }
