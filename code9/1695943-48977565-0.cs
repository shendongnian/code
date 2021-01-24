    public Task<MessageDialogResult> ShowMeasurementFailed(string message)
    {
        var dispatcher = DispatcherHelper.UIDispatcher; // get UI dispatcher from MvvmLight
        return dispatcher.Invoke(() =>
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Continue",
                NegativeButtonText = "Abort"
            };
    
            return dialogCoordinator.ShowMessageAsync(parentViewModel,
                "Measurement has finished",
                "Result: " + message + ".\n\nContinue?",
                MessageDialogStyle.AffirmativeAndNegative,
                mySettings);
        });
    }
