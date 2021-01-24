    public class CreateUserRequest
    {
        [Required]
        [RegularExpressionWithOptions(@"^f1(\.(test|churchstaff|churchuser|internal))?\.\d+\.\d+$", RegexOptions.IgnoreCase)]
        public string Username { get; set; }
        [Required]
        //[RegularExpressionWithOptions(@"^f1\.[\d\w]+$", RegexOptions.IgnoreCase)]
        public string Space { get; set; }
    }
