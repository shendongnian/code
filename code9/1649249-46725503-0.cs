    public class Subtitle
	{
		/// <summary>
		/// Gets the absolute (in the movie timespan) moment where the subtitle must be displayed.
		/// </summary>
		public TimeSpan Moment { get; set; }
		/// <summary>
		/// Gets the text of the subtitle.
		/// </summary>
		public string Text { get; set; }
	}
	public class SubtitleManager
	{
		/// <summary>
		/// Starts a task that display the specified subtitles at the right moment, considering the movie playing start date.
		/// </summary>
		/// <param name="movieStartDate"></param>
		/// <param name="subtitles"></param>
		/// <returns></returns>
		public Task ProgramSubtitles(DateTime movieStartDate, IEnumerable<Subtitle> subtitles)
		{
			return Task.Run(async () =>
			{
				foreach (var subtitle in subtitles.OrderBy(s => s.Moment))
				{
					// Computes for each subtitle the time to sleep from the current DateTime.Now to avoid shifting due to the duration of the subtitle display for example
					var sleep = DateTime.Now - (movieStartDate + subtitle.Moment);
					// Waits for the right moment to display the subtitle
					await Task.Delay(sleep);
					// Show the subtitle
					this.ShowText(subtitle.Text);
				}
			});
		}
		private void ShowText(string text)
		{
			// Since the calling thread is not the UI thread, you will probably need to call the text display in the dispatcher thread !
			Dispatcher.Invoke(() =>
			{
				// show text
			});
		}
	}
