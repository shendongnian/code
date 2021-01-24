    using System.Drawing;
    using System.Drawing.Imaging;
    void Main()
    {
    	double hue = 3.3;
    	double sat = 0.4;
    	double val = 0.9;
    	
    	var wheel = new ColorPicker(400);
    	var img = wheel.DrawImage(hue, sat, val);
    	using (var g = Graphics.FromImage(img))
    	{
    		var pen = val < 0.5 ? Pens.White : Pens.Black;
    		
    		var wheelPosition = wheel.GetWheelPosition(hue);
    		g.DrawEllipse(pen, (float)wheelPosition.X - 5, (float)wheelPosition.Y - 5, 10, 10);
    		
    		var trianglePosition = wheel.GetTrianglePosition(sat, val);
    		g.DrawEllipse(pen, (float)trianglePosition.X - 5, (float)trianglePosition.Y - 5, 10, 10);
    	}
    	img.Dump(); // LINQPad extension method
    }
    public class ColorPicker
    {
    	public int Size { get; }
    
    	public int CenterX => Size / 2;
    	public int CenterY => Size / 2;
    	public int InnerRadius => Size * 5 / 12;
    	public int OuterRadius => Size / 2;
    
    	public ColorPicker(int size = 400)
    	{
    		Size = size;
    	}
    
    	public enum Area
    	{
    		Outside,
    		Wheel,
    		Triangle
    	}
    
    	public struct PickResult
    	{
    		public Area Area { get; set; }
    		public double? Hue { get; set; }
    		public double? Sat { get; set; }
    		public double? Val { get; set; }
    	}
    
    	public PickResult Pick(double x, double y)
    	{
    		var distanceFromCenter = Math.Sqrt((x - CenterX) * (x - CenterX) + (y - CenterY) * (y - CenterY));
    		var sqrt3 = Math.Sqrt(3);
    		if (distanceFromCenter > OuterRadius)
    		{
    			// Outside
    			return new PickResult { Area = Area.Outside };
    		}
    		else if (distanceFromCenter > InnerRadius)
    		{
    			// Wheel
    			var angle = Math.Atan2(y - CenterY, x - CenterX) + Math.PI / 2;
    			if (angle < 0) angle += 2 * Math.PI;
    			var hue = angle;
    			return new PickResult { Area = Area.Wheel, Hue = hue };
    		}
    		else
    		{
    			// Inside
    			var x1 = (x - CenterX) * 1.0 / InnerRadius;
    			var y1 = (y - CenterY) * 1.0 / InnerRadius;
    			if (0 * x1 + 2 * y1 > 1) return new PickResult { Area = Area.Outside };
    			else if (sqrt3 * x1 + (-1) * y1 > 1) return new PickResult { Area = Area.Outside };
    			else if (-sqrt3 * x1 + (-1) * y1 > 1) return new PickResult { Area = Area.Outside };
    			else
    			{
    				// Triangle
    				var sat = (1 - 2 * y1) / (sqrt3 * x1 - y1 + 2);
    				var val = (sqrt3 * x1 - y1 + 2) / 3;
    
    				return new PickResult { Area = Area.Triangle, Sat = sat, Val = val };
    			}
    		}
    	}
    
    	public Image DrawImage(double hue = 0.0, double sat = 1.0, double val = 1.0)
    	{
    		var img = new Bitmap(Size, Size, PixelFormat.Format32bppArgb);
    		for (int y = 0; y < Size; y++)
    		{
    			for (int x = 0; x < Size; x++)
    			{
    				Color color;
    				var result = Pick(x, y);
    				if (result.Area == Area.Outside)
    				{
    					// Outside
    					color = Color.Transparent;
    				}
    				else if (result.Area == Area.Wheel)
    				{
    					// Wheel
    					color = HSV(result.Hue.Value, sat, val, 1);
    				}
    				else
    				{
    					// Triangle
    					color = HSV(hue, result.Sat.Value, result.Val.Value, 1);
    				}
    				img.SetPixel(x, y, color);
    			}
    		}
    
    		return img;
    	}
    
    	private Color HSV(double hue, double sat, double val, double alpha)
    	{
    		var chroma = val * sat;
    		var step = Math.PI / 3;
    		var interm = chroma * (1 - Math.Abs((hue / step) % 2.0 - 1));
    		var shift = val - chroma;
    		if (hue < 1 * step) return RGB(shift + chroma, shift + interm, shift + 0, alpha);
    		if (hue < 2 * step) return RGB(shift + interm, shift + chroma, shift + 0, alpha);
    		if (hue < 3 * step) return RGB(shift + 0, shift + chroma, shift + interm, alpha);
    		if (hue < 4 * step) return RGB(shift + 0, shift + interm, shift + chroma, alpha);
    		if (hue < 5 * step) return RGB(shift + interm, shift + 0, shift + chroma, alpha);
    		return RGB(shift + chroma, shift + 0, shift + interm, alpha);
    	}
    
    	private Color RGB(double red, double green, double blue, double alpha)
    	{
    		return Color.FromArgb(
    			Math.Min(255, (int)(alpha * 256)),
    			Math.Min(255, (int)(red * 256)),
    			Math.Min(255, (int)(green * 256)),
    			Math.Min(255, (int)(blue * 256)));
    	}
    	
    	public PointD GetWheelPosition(double hue)
    	{
    		double middleRadius = (InnerRadius + OuterRadius) / 2;
    		return new PointD
    		{
    			X = CenterX + middleRadius * Math.Sin(hue),
    			Y = CenterY - middleRadius * Math.Cos(hue)
    		};
    	}
    
    	public PointD GetTrianglePosition(double sat, double val)
    	{
    		var sqrt3 = Math.Sqrt(3);
    		return new PointD
    		{
    			X = CenterX + InnerRadius * (2 * val - sat * val - 1) * sqrt3 / 2,
    			Y = CenterY + InnerRadius * (1 - 3 * sat * val) / 2
    		};
    	}
    }
    
    public class PointD
    {
    	public double X { get; set; }
    	public double Y { get; set; }
    }
