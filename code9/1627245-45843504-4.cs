    public class View
    {
        public void Draw(IDrawing drawing)
        {
            // This should ideally be injected using an IOC Framework
            var drawingContext = new SkiaSharpDrawingContext(...);
            //Draw the drawing
            drawing.Draw(drawingContext);
        }
    }
