    public class EpisodeModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual EpisodePatientModel EpisodePatient { get; set; }
    }
    public class EpisodePatientModel
    {
        public string Name { get; set; }
        [Key, ForeignKey("Episode")]
        public int EpisodeId { get; set; }
        public virtual EpisodeModel Episode { get; set; }
    }
