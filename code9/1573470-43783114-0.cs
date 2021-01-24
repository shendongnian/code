    public class Shape {}
    
    public class Cube : Shape {}
    
    public class Sphere : Shape {}
    
    public class Rectangle : Shape {}
    
    public class Ellipse : Shape {}
    public Shape randomShape(ShapeType shapeType)
    {
        switch(shapeType)
        {
             case ShapeType.Cube:
             return new Cube();
             ...
        }
    }
