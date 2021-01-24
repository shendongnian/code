    public class BuildShape : Shape
    {
         public void BuildRectangle()
         {
              var shape = new Shape("Rectangle", "Red");
              Console.WriteLine(shape.TypeOfShape);
              Console.WriteLine(shape.Color);
         }
    }
