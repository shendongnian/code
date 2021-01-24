       private void RunOnUI(Action uiAction, DispatcherPriority dispatcherPriority = DispatcherPriority.Background)
       {
            dispatcher.BeginInvoke(uiAction, dispatcherPriority);
       }
       public void Work(object sender, DoWorkEventArgs e)
       {
            var dispatcher = e.Argument as Dispatcher;
            var dispatcherPriority = DispatcherPriority.Background;
            Action action;
        runOnUI(() =>
        {
            UpdateStatut(StatutsInformation.Pending);
        });
        ViewModel1 viewModel1 = null;
        RunOnUI(() =>
        {
            UpdateProgress(10, "Sampling calculations");
        });
        viewModel1 = Application.GetEchantillonnage();//Long process
        
        List<double> lengthList = null;
        RunOnUI(() =>
        {
            UpdateProgress(20, "Length calculations");            
        });
        lengthList = AlgorithmLibrary.LengthCalculations(viewModel1);//Long process        
        ViewModel2 viewModel2 = null;
        RunOnUI(() =>
        {
            UpdateProgress(30, "Engine calculations");
        };
            viewModel2 = Application.GetEngine();//Long process
            AlgorithmLibrary.EngineCalculations(viewModel2);//Long process
            var FilteredLength = AlgorithmLibrary.LengthFilter(lengthList);//Long process
        ///... Others actions executed incrementing the progress value to 100%
        RunOnUI(() =>
        {
            UpdateStatut(StatutsInformation.Finished);
        });
    }
