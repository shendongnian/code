    public void SetDataContext(IPrescriptionViewModel viewModel)
    {
        if (viewModel == null) return;
        DataContext = viewModel;
        viewModel.CloseAction = this.Close;
    }
