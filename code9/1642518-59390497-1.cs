    public class ExcelUploadViewModel
        {
    
            /// <summary>
            /// Gets or Sets the FileName
            /// </summary>
            [Required(ErrorMessage = "FileName is required")]
            public string FileName { get; set; }
    
            [Required(ErrorMessage = "File is required")]
            [DataType(DataType.Upload)]
            [FromForm(Name = "File")]
            public IFormFile File { get; set; }
    }
