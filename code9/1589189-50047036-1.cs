    public ICommand TextChangeInSearchCommand => new Command(() => SearchInBlank());
       private async void SearchInBlank()
        {
         
            if (string.IsNullOrWhiteSpace(SearchText.Value))
            {
                //Your search in blank.
            }
        }
