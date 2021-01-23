	public class Color
	{
	    public byte Red { get; private set; }
		public byte Green { get; private set; }
		public byte Blue { get; private set; }
		public byte Alpha { get; private set; }
	
		public Color(byte red, byte green, byte blue, byte alpha)
		{
		    this.Red = red;
		    this.Green = green;
		    this.Blue = blue;
		    this.Alpha = alpha;
		}
	}
	Color color = new Color(100, 100, 100, 255);
	byte redValue = color.Red;
	color.Red = 0; // Error, cannot set value outside the class.
