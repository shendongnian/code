    public interface IDrawing
    {
        void Draw();
    }
    public class TextDrawing : IDrawing
    {
        public void Draw()
        {
            // Draw a TextDrawing
        }
    }
    public class ShapeDrawing : IDrawing
    {      
        public void Draw()
        {
            // Draw a ShapeDrawing
        }
    }
    public class SignDrawing : IDrawing
    {
        public TextDrawing Text { get; set; }
        public ShapeDrawing Border { get; set; }
        public void Draw()
        {
            // Draw a SignDrawing
        }
    }
    public class MoreComplexDrawing : IDrawing
    {
        public TextDrawing Text { get; set; }
        public ShapeDrawing Border1 { get; set; }
        public ShapeDrawing Border2 { get; set; }
        public void Draw()
        {
            // Draw a MoreComplexDrawing
        }
    }
    public class View
    {
        public void Draw(IDrawing drawing)
        {
            //Draw the drawing
            drawing.Draw();
        }
    }
