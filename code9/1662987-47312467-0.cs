        private async void OnVendorPropertyChanged(PropertyChangedMessage<Vendor> vendor)
        {
             Debug.WriteLine("Enter OnVendorPropertyChanged");
    
             //application hangs when vendor is changed
             await LoadDriversAsync(Vendor.DCP);
             Debug.WriteLine("Leave OnVendorPropertyChanged");
        }
