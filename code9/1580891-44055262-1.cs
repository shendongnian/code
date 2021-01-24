    public void FillSamplesList(Object o)
    {
        Samples = new ObservableCollection<Sample>();
        //  ...populate...
        SelectedSample = Samples.FirstOrDefault();
    }
    
