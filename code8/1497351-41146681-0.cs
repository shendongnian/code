	internal class MediaPlayerViewModel
	{
		public MediaPlayerViewModel( IEventAggregator eventAggregator )
		{
			MediaPlayerClosedCommand = new DelegateCommand( () => eventAggregator.GetEvent<MediaPlayerClosedEvent>().Publish() );
		}
		public ICommand MediaPlayerClosedCommand { get; }
	}
	internal class MainViewModel
	{
		public MainViewModel( IEventAggregator eventAggregator )
		{
			eventAggregator.GetEvent<MediaPlayerClosedEvent>().Subscribe( ReactToTheEvent );
		}
		private void ReactToTheEvent()
		{
			// do something
		}
	}
	public class MediaPlayerClosedEvent : PubSubEvent
	{
	}
