            Bitmap tempImage = AForge.Imaging.Image.FromFile(imagePath);
            Bitmap image;
            if (tempImage.PixelFormat.ToString().Equals("Format8bppIndexed"))
            {
                image = tempImage;
            }
            else
            {
                image = AForge.Imaging.Filters.Grayscale.CommonAlgorithms.BT709.Apply(tempImage);
            }
            tempImage.Dispose();
            AForge.Imaging.DocumentSkewChecker skewChecker = new AForge.Imaging.DocumentSkewChecker();
            // get documents skew angle
            double angle = skewChecker.GetSkewAngle(image);
            // create rotation filter
            AForge.Imaging.Filters.RotateBilinear rotationFilter = new AForge.Imaging.Filters.RotateBilinear(-angle);
            rotationFilter.FillColor = Color.Black;
            // rotate image applying the filter
            Bitmap rotatedImage = rotationFilter.Apply(image);
            var deskewedImagePath = folderSavePath + filename + "_deskewed.tiff";
            rotatedImage.Save(deskewedImagePath, System.Drawing.Imaging.ImageFormat.Tiff);
            image.Dispose();
            rotatedImage.Dispose();
