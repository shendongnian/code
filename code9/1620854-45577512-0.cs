    public class Window {
        private int top;  //these two members are private which means only the containing class can access them.
        private int left;
    
        public Window(int top, int left) {
            this.top = top;
            this.left = left;
        }
        public virtual void DrawWindow() {
            Console.WriteLine("Drawing Window at {0}, {1}", top, left);
        }
    }
    
    public class Button : Window {
        public Button(int top, int left): base(top, left) {
        }
        
        public override void DrawWindow() {
            base.DrawWindow();
            Console.WriteLine("Drawing a button at {0}, {1}", top, left); // Here you are trying to access the private members of the base class which is not allowed.  This is what is causing your error
        }
    }
