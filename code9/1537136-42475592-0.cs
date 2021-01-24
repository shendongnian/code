	//get trainingimages
	var trainingImages = Directory.GetFiles(
	   "C:\\Users\\tub08918\\Google Drive\\Patil Lab\\AlexsFolderPleaseVisitMe\\ISIC-2017_Training_Data\\ISIC-2017_Training_Data",
	   "*.jpg"
	).ToList();
	for (var i = 0; i < trainingImages.Count; i++)
	{
		using (var image = Image.FromFile(trainingImages[i]))
		{
			using (var bm = new Bitmap(image))
			{
				using (var vsImage = ConvertBitmap(bm))
				{
					var imgArray = new int[vsImage.Width, vsImage.Height, 3];
					for (var j = 0; j < vsImage.Width; j++)
					{
						for (var z = 0; z < vsImage.Height; z++)
						{
							var p = vsImage.GetPixel(j, z);
							imgArray[j, z, 0] = p.R;
							imgArray[j, z, 1] = p.G;
							imgArray[j, z, 2] = p.B;
						}
					}
				}
			}
		}
	}
