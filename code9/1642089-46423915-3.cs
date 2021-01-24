    public void SelectedObjectsGridSelectionChangedCommand(object parameter)
    {
        object data = null;
        IList selectedRows = parameter as IList;
        if (selectedRows.Count == 1)
            data = (SelectedNetObjectBindingSource)selectedRows[0]).Data;
        Task.Factory.StartNew(() =>
        {
            ObjectProperties.Instance.SetAttributeObjectNoRefresh(null);
            Parallel.Invoke(
                () => SetAttributeObjectExtraHightlight<SelectedNetObjectBindingSource>(selectedRows),
                () => DoSomeOtherStuff(selectedRows));
        }).ContinueWith(task =>
        {
            ((ObjectViewModel)MyApp.ViewModels["Shared.Panels.Object"]).SelectedObjectsChanged();
        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
