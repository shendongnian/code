    public static CoordinatesAndDimensionsModel RotatePoint(CoordinatesAndDimensionsModel page, CoordinatesAndDimensionsModel field, int angleInDegrees)
    {
    	double newX, newY;
    
    	switch (angleInDegrees) {
    
    		case 90:
    		case -270:
    			newX = page.Width - field.Y - field.Height;
    			newY = field.X;
    			return new CoordinatesAndDimensionsModel(newX, newY, field.Height, field.Width);
    
    		case 180:
    		case -180:
    			newX = page.Width - field.X - field.Width;
    			newY = page.Height - field.Y - field.Height;
    			return new CoordinatesAndDimensionsModel(newX, newY, field.Width, field.Height);
    
    		case -90:
    		case 270:
    			newX = field.Y;
    			newY = page.Height - field.X - field.Width;
    			return new CoordinatesAndDimensionsModel(newX, newY, field.Height, field.Width);
    
    		default:
    			return new CoordinatesAndDimensionsModel(field.X, field.Y, field.Width, field.Height);
    	}
    }
    
    public class CoordinatesAndDimensionsModel
    {
    	public CoordinatesAndDimensionsModel() {}
    
    	public CoordinatesAndDimensionsModel(double x, double y, double width, double height)
    	{
    		this.X = x;
    		this.Y = y;
    		this.Width = width;
    		this.Height = height;
    	}
    
    	public double X { get; set; }
    	public double Y { get; set; }
    	public double Width { get; set; }
    	public double Height { get; set; }
    }
