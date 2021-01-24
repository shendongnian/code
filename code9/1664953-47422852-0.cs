    public class DraggableContentView : ContentView
    {
        public event EventHandler TouchEnded;
        public event EventHandler TouchesBegan;
        public event EventHandler PositionChanged;
    
        public void InvokeTouchBegan()
        {
            var parentLayout = Parent as Layout<View>;
            parentLayout?.RaiseChild(this);
            TouchesBegan?.Invoke(this, EventArgs.Empty);
        }
    
        public void InvokePositionChanged()
        {
            PositionChanged?.Invoke(this, EventArgs.Empty);
        }
    
        public void InvokeTouchEnded()
        {
            TouchEnded?.Invoke(this, EventArgs.Empty);
        }
    }
