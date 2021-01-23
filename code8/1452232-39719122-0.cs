    imageRotate = imgGray.Rotate(-avg, new Gray(255));
            }
            else
            {
                imageRotate = imgGray;
            }
            imgGray.Dispose();
    
            //return imageRotate.Bitmap;
            return BlackFilterImage(imageRotate);
        }
    
        private static Bitmap BlackFilterImage(Image<Gray, byte> img)
        {
            UMat resultImg = new UMat();
            CvInvoke.Threshold(img, resultImg, 105, 255, ThresholdType.BinaryInv); //Error is here
