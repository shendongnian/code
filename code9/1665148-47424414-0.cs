	public Color SelectedColor
	{
		get { return ColorFromText(SelectedColorAsText); }
		set
		{
			String	newColorAsText;
			newColorAsText = TextFromColor(value);
			if (newColorAsText != SelectedColorAsText)
			{
				SelectedColorAsText = newColorAsText;
				OnPropertyChanged(nameof(SelectedColor));
			}
		}
	}
	public String SelectedColorAsText { get; set; }
	private Color ColorFromText(String text)
	{
		Byte	a, r, g, b;
		a = Byte.Parse(text.Substring(1, 2),	System.Globalization.NumberStyles.AllowHexSpecifier);
		r = Byte.Parse(text.Substring(3, 2),	System.Globalization.NumberStyles.AllowHexSpecifier);
		g = Byte.Parse(text.Substring(5, 2),	System.Globalization.NumberStyles.AllowHexSpecifier);
		b = Byte.Parse(text.Substring(7, 2),	System.Globalization.NumberStyles.AllowHexSpecifier);
		return Color.FromArgb(a, r, g, b);
	}
	private String TextFromColor(Color color)
	{
		return color.ToString();
	}
