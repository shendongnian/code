    public void OnNetworkAvailabilityChanged(bool isAvailable)
    {
        Application.Current.Dispatcher.Invoke(() => {
            if (isAvailable)
            {
                // Change color to available
                return;
            }
    
            //Change color to unavailable
        });
    }
