    using (var image = Image.FromFile(trainingImages[i]))
    {
        using (var bitmap = new Bitmap(image))
        {
            using (var vsImage = ConvertBitmap(bitmap))
            {
                //cnvert to 2d array
                var imgArray = new int[vsImage.Width, vsImage.Height, 3];
                for (var j = 0; j < vsImage.Width; j++)
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
