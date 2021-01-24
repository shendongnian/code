    public interface ISettingProvider
    {
        bool PauseOnLastFrame;
    	bool IsAutoPlay;
        MediaStatus PlayingMediaStatus;
    
        void SaveSettings();
    }
    public class SettingProvider : ISettingProvider
    {
        private bool pauseOnLastFrame;
        public bool PauseOnLastFrame  // read-write instance property
        {
            get
            {
                return pauseOnLastFrame;
            }
            set
            {
                pauseOnLastFrame = value;
                Settings.Default.PauseOnLastFrame = volumne;
            }
        }
    	
    	private bool isAutoPlay;
        public bool IsAutoPlay  // read-write instance property
        {
            get
            {
                return isAutoPlay;
            }
            set
            {
                isAutoPlay = value;
                Settings.Default.IsAutoPlay = volumne;
            }
        }
    }
    public class SettingsViewModel : ViewModelBase
    {
        SettingProvider objSettingProvider = new SettingProvider();
    	
        
    	MediaStatus PlayingMediaStatus 
    	{
            get
            {
                return objSettingProvider.PlayingMediaStatus;
            }
            set
            {
    			if(value == MediaStatus.Paused)
    				MediaPlayer.Pause();
    				
    			if(value == MediaStatus.Playing)
    				MediaPlayer.Play();
    			
    			if(value == MediaStatus.Stopped)
    				MediaPlayer.Stop();
    		
                objSettingProvider.PlayingMediaStatus  = (int)value;
                
    			OnPropertyChanged("PlayingMediaStatus");
            }
        }
    	
    	private string currentMediaFile;
    	public string CurrentMediaFile
    	{
    		get
            {
                return currentMediaFile;
            }
            set
            {
    			currentMediaFile  = value;
    			
    			MediaPlayer.Stop();
    			MediaPlayer.Current = currentMediaFile;
    			
    			if(objSettingProvider.IsAutoPlay)
    				MediaPlayer.Play();
                
    			OnPropertyChanged("CurrentMediaFile");
            }
    	}
    	
    	// Implementaion of other properties of SettingProvider with your ViewModel properties;
    
    
        private ICommand onMediaEndedCommand;
        public ICommand OnMediaEndedCommand
        {
            get
            {
                return onMediaEndedCommand ?? (onMediaEndedCommand = new CommandHandler(param => onMediaEnded(param), true));
            }
        }
    
        private void onMediaEnded()
        {
            if(objSettingProvider.PauseOnLastFrame)
    		{
    			PlayingMediaStatus = MediaStatus.Paused;
    		}
    		
    		else if(PlayListViewModel.FilesCollection.Last().Equals(PlayListViewModel.FilesCollection.Current) && !Repeat)
    		{
    			PlayingMediaStatus = MediaStatus.Stopped;
    		}
    		
    		else
    		{
    			CurrentMediaFile = PlayListViewModel.FilesCollection.MoveNext();
    		}
        }
    }
