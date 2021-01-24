    private void ContentBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ContentBox.SelectedItem != null)// ContentBox is your listbox
            {
    
               Benutzer obj = ContentBox.SelectedItem as Benutzer;
                if(obj != null)
                {
                    string name = obj.UserName;
                }
    
                ContentBox.SelectedItem = null;
            }
        }
