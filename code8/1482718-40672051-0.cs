    {
        IsBusy = true;
        await Task.WhenAll(
            _synchronisation.SynchronizeUsersRights(),
            _synchronisation.SynchronizeServerData(),
            _synchronisation.SynchronizeForms(),
            _synchronisation.SynchronizeViews());
        IsBusy = false;
    }
