    public class Window 
    {
        protected int Top { get; private set; }
        protected int Left { get; private set; }
    
        public Window (int top, int left) 
        {
            Top = top;
            Left = left;
        }
        
        public virtual void DrawWindow() 
        {
            Console.WriteLine("Drawing Window at {0}, {1}", Top, Left);
        }
    }
