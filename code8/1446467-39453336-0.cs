    public class Window1 : Window
    {
        private Info info = null;
        private Boolean IsInfoOpened = false;
    
        protected void OpenInfo()
        {
            if (this.IsInfoOpened) return;
            this.info = new Info();
            this.info.ContentRendered += delegate { this.IsInfoOpened = true; };
            this.info.Closed += delegate { this.IsInfoOpened = false; }
            this.info.Show();
        }
    }
