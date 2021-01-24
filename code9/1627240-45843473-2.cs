    public class SignDrawing : IDrawing
    {
        public TextDrawing Text { get; set; }
        public ShapeDrawing Border { get; set; }
        public void Draw()
        {
            Text.Draw();
            Border.Draw();
            Text.Draw();
        }
    }
