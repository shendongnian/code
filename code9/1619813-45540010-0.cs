                public string imagePath { get; set; }
    
                [Display(Description = "imgfile")]
                [RegularExpression(@"([a-zA-Z0-9()\s_\\.\-:!@#$%^&])+(.png|.jpg|.gif|.bmp|.tiff|.PNG|.JPG|.GIF|.BMP|.TIFF)$", ErrorMessage = "Only Image files allowed.")]
                public HttpPostedFileBase imgfile { get; set; }
