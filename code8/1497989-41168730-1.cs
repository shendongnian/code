    public partial class Window1 : Window
    {
        Queue<Point> _locations = new Queue<Point>();
        public Window1()
        {
            InitializeComponent();
            _locations.Enqueue(new Point(this.Left, this.Top));
            LocationChanged += (s, e) => _locations.Enqueue(new Point(this.Left, this.Top)); ;
            SizeChanged += (s, e) => 
            {
                if(IsLoaded)
                {
                    Point lastPosition = _locations.Dequeue();
                    while (lastPosition.X == this.Left && lastPosition.Y == this.Top && _locations.Count > 0)
                        lastPosition = _locations.Dequeue();
                    if (_locations.Count == 0)
                        _locations.Enqueue(lastPosition);                    
                    //...
                }
            };
        }
     }
