	private static MagickImage ChangeWhiteColor(MagickImage Image, Color TargetColor, int fuzz)
		{
			Image.ColorFuzz = new Percentage(fuzz);
			Image.Opaque(MagickColor.FromRgb((byte)255, (byte)255, (byte)255), 
				MagickColor.FromRgb(TargetColor.R,
				TargetColor.G,
				TargetColor.B));
			return Image;
		}
		
