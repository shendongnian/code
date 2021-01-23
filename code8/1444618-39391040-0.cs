	public class EpisodeModel
	{
		public int ID { get; set; }
		public virtual ICollection<EpisodePatientModel> EpisodePatients { get; set; } // Must be collection
	}
	
	public class EpisodePatientModel
	{
		public int EpisodePatientID { get; set; }
		public int EpisodeID { get; set; } // Foreign key to Episode
		public virtual EpisodeModel Episode { get; set; }
	}
