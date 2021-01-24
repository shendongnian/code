    public class Window {
        protected int top;  //these two members are now protected private which means derived classes can access them.
        protected int left;  
    
        public Window(int top, int left) {
            this.top = top;
            this.left = left;
        }
        public virtual void DrawWindow() {
            Console.WriteLine("Drawing Window at {0}, {1}", top, left);
        }
    }
