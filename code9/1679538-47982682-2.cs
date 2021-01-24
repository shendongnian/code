    // Shape: Object (Sub Class)
    // ShapeColor: Base Object (Base Class)
    public class Shape : ShapeColor 
    {
         private string shape;   
    
         public Shape(string shape, string color) : base(color)
         {
              this.shape = shape;
         }
    
         public string TypeOfShape { get; } = shape;
    }
