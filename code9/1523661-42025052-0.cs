	public class Track 
	{ 
		public bool IsGoodTrack => true;
	}
	
	public class TrackList : IEnumerable<Track>
	{
		private List<Track> tracks = new List<Track>();
		public IEnumerator<Track> GetEnumerator()
		{
			// Implement custom logic here.
			foreach (var track in tracks)
			{
				if (track.IsGoodTrack())
				  yield return track;
			}
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
		
