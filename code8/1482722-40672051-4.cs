    {
        IsBusy = true;
        Task resUsersTask = _synchronisation.SynchronizeUsersRights();
        Task resServerTask = _synchronisation.SynchronizeServerData();
        Task resFormTask = _synchronisation.SynchronizeForms();
        Task resViewsTask = _synchronisation.SynchronizeViews();
        await Task.WhenAll(resUsersTask, resServerTask, resFormTask, resViewsTask);
        var resUsers = resUsersTask.Result;
        var resServer = resServerTask.Result;
        var resForm = resFormsTask.Result;
        var resViews = resViewsTask.Result;       
        IsBusy = false;
    }
