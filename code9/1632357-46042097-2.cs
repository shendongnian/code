    public ObservableCollection<ShippingDetail> ShippingDetails
    {
        get { return ShippingDetailList; }
        set
        {
            ShippingDetailList = value;
            OnPropertyChanged("ShippingDetails");
        }
    }
