        private void FormLoadComplete(object parameter)
        {
        	IsBusy = true;
        	Task.Run(() =>
        	{
        		LoadData();
        		Application.Current.Dispatcher.Invoke(() => IsBusy = false);
            });
        }
