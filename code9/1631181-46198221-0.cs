    		public static System.Windows.Forms.ImageList ProcessHighContrast(System.Windows.Forms.ImageList imageList)
		{
			if (System.Windows.Forms.SystemInformation.HighContrast)
			{
				System.Windows.Forms.ImageList imageListNew = new ImageList();
				
				foreach (System.Drawing.Bitmap imageListImage in imageList.Images)
				{
					for (int i = 0; i < imageListImage.Width; i++)
					{
						for (int j = 0; j < imageListImage.Height; j++)
						{
							Color color = imageListImage.GetPixel(i, j);
							if (System.Drawing.Color.FromArgb(255, 0, 0, 0).Equals(color))
								imageListImage.SetPixel(i, j, System.Drawing.SystemColors.WindowText);
						}
					}
					imageListNew.Images.Add(imageListImage);
				}
				return imageListNew;
			}
			return imageList;
		}
