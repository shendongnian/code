	public class SoundDependency : ISound
	{
		public SoundDependency() { }
		MediaPlayer player;
		public void startSound(string fileName)
		{
			player = new MediaPlayer(); // Create media player
			var assetFile = Xamarin.Forms.Forms.Context.Assets.OpenFd(fileName); // Open the resource
			// Hook up some events
			player.Prepared += (sender, args) =>
			{
				player.Start();
			};
			player.SetDataSource(assetFile.FileDescriptor, assetFile.StartOffset, assetFile.Length);
			player.Prepare();
		}
		public void PauseAudioFile(string fileName)
		{
			if (player != null)
			{
				player.Pause();
			}
			else
			{
				
			}
		}
	}
}
