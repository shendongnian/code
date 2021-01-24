			using (MagickImageCollection image = new MagickImageCollection())
			{
				MagickReadSettings settings = new MagickReadSettings();
				settings.Density = new Density(300, 300); // Settings the density to 300 dpi will create an image with a better quality
				settings.FrameIndex = 0; // First page
				settings.FrameCount = 1; // Number of pages
				image.Read(@"source.pdf", settings);
				image.Write(@"output.tif");
			}
