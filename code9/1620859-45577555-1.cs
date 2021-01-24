    public class Button : Window
    {
        public Button(int top, int left): base(top, left) 
        {
        }
        public override void DrawWindow() 
        {
            base.DrawWindow();
            Console.WriteLine("Drawing a button at {0}, {1}", Top, Left);
        }
    }
