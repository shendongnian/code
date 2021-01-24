    private void OnMediaEndedCommand()
    {
        if (GeneralSettings.MediaEndedHandler.AlternateHandling(MediaPlayer))
            return;
        if (PlayListViewModel.FilesCollection.Last().Equals(PlayListViewModel.FilesCollection.Current) && !Repeat)
        {
            ChangeMediaPlayerSource(PlayListViewModel.ChangeCurrent(() => PlayListViewModel.FilesCollection.MoveNext()));
            MediaPlayer.SetMediaState(MediaPlayerStates.Stop);
            return;
        }
        ChangeMediaPlayerSource(PlayListViewModel.ChangeCurrent(() => PlayListViewModel.FilesCollection.MoveNext()));
    }
