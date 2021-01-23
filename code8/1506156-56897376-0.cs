        ...
        foreach(var serviceViewModel in ServiceViewModels)
        {
            var timer = new Timer(PollSource, serviceViewModel, 0, serviceViewModel.PollingInterval * 1000);
        }
    }
            
    private void PollSource(object stateInfo)
    {
    }
