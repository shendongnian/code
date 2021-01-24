    public class Unidad {
        public event EventHandler MouseDown;
        
        public void someMethode()
        {
            // Raise the event
            OnMouseDown(EventArgs.Empty);
        }
        
        protected void OnMouseDown(EventArgs e)
        {
            if (MouseDown != null)
                MouseDown(this, e);
        }
    }
