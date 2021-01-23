    public class EpisodeModel
    {
        public int ID { get; set; }
        public virtual IEnumerable<EpisodePatientModel> EpisodePatients { get; set; }
    }
    public class EpisodePatientModel
    {
        public int EpisodePatientID { get; set; }
        public int EpisodeID { get; set; }
        public virtual EpisodeModel Episode { get; set; }
    }
