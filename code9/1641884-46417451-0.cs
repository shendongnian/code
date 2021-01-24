        Bitmap TestImage1 = (Bitmap)Image.FromFile(filePath);
        Console.WriteLine(TestImage1.GetPixel(0, 0).ToString());
        ImageList IL = new ImageList();
        IL.Images.Add(TestImage1);
		Bitmap TestImage2 = (Bitmap)IL.Images[0];
		
        Console.WriteLine(TestImage2.GetPixel(0, 0).ToString());
        Console.WriteLine(TestImage1.GetPixel(0, 0).ToString());
		
		Console.WriteLine(TestImage1.Equals(TestImage2));
