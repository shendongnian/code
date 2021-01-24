    public class Border : IDrawable
    {
        private IDrawable _drawable;
        public class Border(IDrawable drawable)
        {
          _drawable = drawable;
        }
        private InternalDrawWithSomeSpecialLogicAndStuff() { ... }
        public void Draw()
        {
            //draw the decorated item:
            _drawable?.Draw();
            //and work out some magic to draw a border around it,
            //note that properties as dimensions would be helpful.
            InternalDrawWithSomeSpecialLogicAndStuff();
        }
    }
