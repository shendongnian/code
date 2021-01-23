        using CoreImage;
        using UIKit;
        using CoreGraphics;
        public static UIImage GaussianFilter(UIImage image)
		{
			CIImage ciImage = new CIImage(image);
            //ciImage.CreateByApplyingGaussianBlur(2);
            var gaussianFilter = new CIGaussianBlur() { Image = ciImage, Radius = 0.8f};
			CIImage output = gaussianFilter.OutputImage;
			var context = CIContext.FromOptions(null);
			var cgimage = context.CreateCGImage(output, output.Extent);
            var uiImage = UIImage.FromImage(cgimage);
            return uiImage;
        }
