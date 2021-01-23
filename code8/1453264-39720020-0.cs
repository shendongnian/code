    private DelegateCommand<Item> _deleteItem = default(DelegateCommand<Item>);
    
    public DelegateCommand<Item> DeleteItem => _deleteItem ?? (_deleteItem = new DelegateCommand<Item>(ExecuteDeleteItemCommand, CanExecuteDeleteItemCommand));
    
    ...
    private bool CanExecuteDeleteItemCommand(Item item)
    {
        return true;
    }
    
    private void ExecuteDeleteItemCommand(Item item)
    {
        _items.Remove(item);
    }
