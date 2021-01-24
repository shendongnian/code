    async void OnItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            
            var itemPage = new TestPage();
            await Navigation.PushAsync(itemPage);
        }
