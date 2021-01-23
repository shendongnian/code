    var dealers = new List<DealerViewModelBase>
    {
        new Dealer1ViewModel (),
        new Dealer2ViewModel ()
    }
    foreach(var dealer in dealers)
    {
        dealer.UpdatePrice();
    }
