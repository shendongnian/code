	var originalImage = UIImage.FromBundle("buymore.jpg");
	var watermarkImage = UIImage.FromFile("vs.png");
	UIGraphics.BeginImageContextWithOptions(originalImage.Size, true, 1.0f);
	originalImage.Draw(CGPoint.Empty);
	watermarkImage.Draw(new CGRect(new CGPoint(200, 200), watermarkImage.Size));
	var processedImage = UIGraphics.GetImageFromCurrentImageContext();
