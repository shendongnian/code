    public class CustomPanel : Panel
    {
        public int DefaultHeight { get; private set; }
        public CustomPanel()
        {
            // Add an event, which gets triggered at the next resize.
            // We need this event, because at initializing the Control have the default Height.
            // The Resize event getting triggered, when the Form load and initializes the Controls.
            this.Resize += this.Initial_Resize;
        }
                        
        private void Initial_Resize(object sender, EventArgs e)
        {
            // Set the DefaultHeight to the value of the new Size
            this.DefaultHeight = this.Height;
            // Remove the event, otherwise DefaultHeight would get overridden at every resize.
            this.Resize -= this.Initial_Resize;
        }
    }
