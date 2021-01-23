		public async void play()
		{
			
			System.Diagnostics.Debug.WriteLine("Play 1");
			await PlayAudioTask("wave2.wav");
			System.Diagnostics.Debug.WriteLine("Play 2");
			await PlayAudioTask("wave2.wav");
			System.Diagnostics.Debug.WriteLine("Play 3");
			await PlayAudioTask("wave2.wav");
		}
		private AVAudioPlayer player;  // Leave the player outside the Task
		public Task<bool> PlayAudioTask(string fileName)
		{
			var tcs = new TaskCompletionSource<bool>();
			// Any existing sound playing?
			if (player != null)
			{
				//Stop and dispose of any sound
				player.Stop();
				player.Dispose();
			}
			string filePath = NSBundle.MainBundle.PathForResource(
					Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
			var url = NSUrl.FromString(filePath);
			player = AVAudioPlayer.FromUrl(url);
			player.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
			{
				System.Diagnostics.Debug.WriteLine("DONE PLAYING");
				player = null;
				tcs.SetResult(true);
			};
			player.NumberOfLoops = 0;
			System.Diagnostics.Debug.WriteLine("Start Playing");
			player.Play();
			return tcs.Task;
		}
