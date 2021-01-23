    public TestSuiteViewModel()
    {
            LoadData();
            LoadCommand();
            Messenger.Messenger.Default.Register<ThePayLoad>(this, OnPlanPopulated,"PlanUpdated");
    }
    private void OnPlanPopulated(ThePayLoad payload)
    {  
        methodThatWillPopulateTheTreeView(payLoad.SelectedPlan, payLoad.treeView)
    }
