    ....
    private TicketViewModel _viewModel = new TicketViewModel();
    ....
    public async void OnItemTapped (object o, ItemTappedEventArgs e) { //Notice I added 'async' to the method here, that is so we can 'await' the DisplayAlert below (ALWAYS 'await' the DisplayAlert and ANY other async methods)
        TicketListItem item = (TicketListItem)o;
        if (item != null) {
            await DisplayAlert("Alert", "Your have been alerted", "OK"); //Notice the 'await' here
            _viewModel.SelectedTicket = null;
        }
    }
