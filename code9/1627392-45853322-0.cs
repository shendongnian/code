    public class peopleMetaData
    {
        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(50, MinimumLength = 2)]
        public string firstName;
    }
