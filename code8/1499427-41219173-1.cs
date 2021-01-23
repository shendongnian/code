    static void MergeImages(params Image[] images)  //allows a variable number of arguments 
    {
        int currentImgHeight = 0;
        using (Bitmap FinalBitmap = new Bitmap(images.Max(img => img.Width), images.Sum(img => img.Height)))
        {
            using (Graphics FinalImage = Graphics.FromImage(FinalBitmap))
            {
                foreach (var img in images)
                {
                    currentImgHeight += img.Height; //counter upwards for height
                    FinalImage.DrawImage(img, img.Width, currentImgHeight);
                }
                FinalImage.Save();
                FinalBitmap.Save(MapPath("~/ResultImages/Resultimg.PNG"));
                MergedCombinedImage.ImageUrl = "~/ResultImages/Resultimg.PNG";
            }
        }
    }
