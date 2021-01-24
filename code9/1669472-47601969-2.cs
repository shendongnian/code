    public class Tile : Notifier
    {
        private string _name = "Click me";
        public string Name
        {
            get
            {
                return _name;
            }
            set { _name = value; Notify(); }
        }
    }
