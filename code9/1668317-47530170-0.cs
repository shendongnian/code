        private void AuthorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteAuthortButton.IsEnabled = true;
            SaveChangesButton.IsEnabled = true;
        
            var aa = sender as ListBox;
            if (aa.SelectedItem != null)
            {
               var author = aa.SelectedItem as Author;
        
               IdTextBox.Text = author.Id.ToString();
               AuthorNameTextBox.Text = author.Name;
               NationalityTextBox.Text = author.Nationality; 
            }
        }
