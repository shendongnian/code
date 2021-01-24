    using System;
    public abstract class Shape {
	    public string shapeType {get; set;}
	    public abstract double Area { get; }
    }
    public class Circle : Shape
    {
	    public int radius {get; set;}
	    public override double Area { get { return 3.1415 * radius * radius;} }
    }
    public class Square : Shape
    {
	    public int length {get; set;}
	    public override double Area { get { return length * length;} }
    }
					
    public class Program
    {
	    public static void Main()
	    {
		    Console.WriteLine("Hello World {0}" , "foo");
		    var circle = new Circle() {shapeType= "Circle", radius = 5};
		    var square = new Square() {shapeType= "Square",length = 5};
		
		    webApiControllerAction(circle);
		    webApiControllerAction(square);
        }
	
	    public static void webApiControllerAction(Shape shape)
	    {
		    // just call the appropriate printArea for the derived type
		    printArea(shape);
	    }
		
	    public static void printArea(Shape s) {
		    Console.WriteLine("{0} area = {1}", s.GetType().Name ,s.Area.ToString());
	    }
    }
