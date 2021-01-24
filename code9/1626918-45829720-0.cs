    public interface IRotate
    {
        void Rotate(float degree);
    }
    public class SquareDrawing : Drawing, IRotate
    {
        public void Rotate(float degree)
        {
             //actual code to rotate the drawing
        }
    }
    public class RectangleDrawing : CompoundDrawing
    {
         public RectangleDrawing(IList<LineDrawing> lineDrawings) : base(lineDrawings)
         {
            foreach(var line in lineDrawings)
            {
                if (line is IRotate)
                {
                     ((IRotate)line).Rotate(45.0);
                }
            }
         }    
    }
