    public ICommand RemoveSelectedItem()
    {
       return  new RelayCommand<ItemModel>(RemoveSelectedItemFromList);
    }
    private void RemoveSelectedItemFromList(ItemModel item)
    {
       MessageDialogs.ShowInfoMessage(item.Name);
    }
