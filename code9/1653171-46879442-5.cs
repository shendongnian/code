    public class Rectangle : IDrawable
    {
        private IDrawable _drawable;
        public class Rectangle(IDrawable drawable)
        {
          _drawable = drawable; //just to make it uniform
        }
        private InernalDraw() { ... }
        public void Draw()
        {
            //do the drawing magic
            InernalDraw(); //some drawing code
            //and do something with the decorated item
            _drawable?.Draw();
        }
    }
