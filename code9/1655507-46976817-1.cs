    private void OnDrop(object sender, DragEventArgs e)
    {
        var viewModel = DataContext as YourViewModelType;
        if (viewModel != null)
            viewModel.OnRectangleDrop.Execute(e);
    }
