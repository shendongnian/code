    public class EmailForm
    {
        [Display(Name = "Add a picture")]
        [DataType(DataType.Upload)]
        public IFormFile SubmitterPicture { get; set; }
    }
