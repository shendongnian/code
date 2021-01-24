    public class YourViewModel : BaseViewModel
    {
        private void OnMediaEndedCommand()
        {
            if (GeneralSettings.PauseOnLastFrame)
            {
                MediaPlayer.SetMediaState(MediaPlayerStates.Pause);
                return;
            }
            if (PlayListViewModel.FilesCollection.Last().Equals(PlayListViewModel.FilesCollection.Current) && !Repeat)
            {
                ChangeMediaPlayerSource(PlayListViewModel.ChangeCurrent(() => PlayListViewModel.FilesCollection.MoveNext()));
                MediaPlayer.SetMediaState(MediaPlayerStates.Stop);
                return;
            }
            ChangeMediaPlayerSource(PlayListViewModel.ChangeCurrent(() => PlayListViewModel.FilesCollection.MoveNext()));
        }
    }
