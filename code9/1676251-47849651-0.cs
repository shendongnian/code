            DeleteListItem = new Command(async (parameter) => {
                ListItem item = (ListItem)parameter as ListItem;
                await App.ListItemRepo.DeleteListItemAsync(item);
                ObservableCollection<ListItem> commandActiveItems =
                    new ObservableCollection<ListItem>(
                        App.ListItemRepo.GetActiveListItems());
                activeList.ItemsSource = commandActiveItems;
                activeList.HeightRequest = 50 * commandActiveItems.Count;
                ObservableCollection<ListItem> commandInactiveItems =
                    new ObservableCollection<ListItem>(
                        App.ListItemRepo.GetInactiveListItems());
                inactiveList.ItemsSource = commandInactiveItems;
                inactiveList.HeightRequest = 50 * commandInactiveItems.Count;
            });
