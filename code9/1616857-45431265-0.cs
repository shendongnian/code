    public class CustomPanel : Panel
    {
        public int DefaultHeight { get; private set; }
        public CustomPanel()
        {
            this.Resize += this.Initial_Resize;
        }
                        
        private void Initial_Resize(object sender, EventArgs e)
        {
            this.DefaultHeight = this.Height;
            this.Resize -= this.Initial_Resize;
        }
    }
