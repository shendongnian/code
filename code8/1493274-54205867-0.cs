    public class Project
    {
        [Required]
        public string ProjectName { get; set; }
        [JsonIgnore]
        public string SomeValueYouWantToIgnore { get; set; }
    }
