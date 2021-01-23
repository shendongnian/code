    public partial class Condensed : UserControl
    {
        private string Path; // No static here
    
        public Sender Export()
        {
               this uses Path to Load data then return it to the main class
        }
    
        public void Load(string path)
        {
              Path = path
        }
    }
