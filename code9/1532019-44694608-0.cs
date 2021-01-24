    OrdersToConfirm = new ObservableCollection<mConfirmedQuote>(_quoteService.GetOrdersToBeConfirmed());
    OrdersToConfirm.ToList().ForEach(x => { x.PropertyChanged += item_PropertyChanged; });
    private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
         ConfirmCommand.RaiseCanExecuteChanged();
    }
