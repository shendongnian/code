    public class View
    {
        public void Draw(IDrawing drawing)
        {
            // This should ideally be injected using an IOC framework
            var drawingContext = new SkiaSharpDrawingContext(...);
            //Draw the drawing
            drawing.Draw(drawingContext);
        }
    }
