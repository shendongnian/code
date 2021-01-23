	// directory path which you are going to list the image files
	var sourceDir = "directory path";
	// temp variable for counting file order
	int fileOrder = 0;
	// list of allowed file extentions which the code should find
	var allowedExtensions = new[] {
	 ".jpg",
	 ".png",
	 ".gif",
	 ".bmp",
	 ".jpeg"
	};
	// find all allowed extention files and append them into a list of Photo class
	var photos = Directory.GetFiles(sourceDir)
						  .Where(file => allowedExtensions.Any(file.ToLower().EndsWith))
						  .Select(imageFile => new Photo()
						  {
							  ShowOrder = ++fileOrder,
							  Format = imageFile.Substring(imageFile.LastIndexOf(".")),
							  Image = File.ReadAllBytes(imageFile)
						  })
						  .ToList();
