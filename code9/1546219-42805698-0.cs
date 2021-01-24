            private void FormLoadComplete(object parameter)
        {   
            IsBusy = true;
            Dispatcher.Invoke(() => {
                LoadData();
                IsBusy = false;
    			});
        }
    Your have to leave the first event handler.
