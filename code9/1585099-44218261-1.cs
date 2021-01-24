    public partial class DDitem : UserControl
    {
        private string _name;
        private string _path;
        private Point position;
        public string name
        {
            get;
            set;
        }
        public string path
        {
            get;
            set;
        }
        public DDitem(string name, string path)
        {
            this.name = name;
            this.path = path;
            this.Width = 100;
            this.Height = 100;
            this.DataContext=this;
            InitializeComponent();
        }
        public Point getPosition()
        {
            return position;
        }
        public void setPosition(Point pos)
        {
            position = pos;
        }
    }
