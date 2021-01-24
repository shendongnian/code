    public partial class MyClass : Form
    {
        private readonly Image _image;
        private readonly Point _position;
        private bool _isImageVisible;
        public MyClass()
        {
            InitializeComponent();
            _image = Image.FromFile(@"C:\img.png");
            _position = new Point(100, 100);
            var addImageCountdown = new Timer
            {
                Enabled = true,
                Interval = 3000,
            };
            addImageCountdown.Tick += new EventHandler(AddImage);
            addImageCountdown.Start();
        }
        private void AddImage(Object myObject, EventArgs myEventArgs)
        {
            _isImageVisible = true;
            Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if(_isImageVisible)
            { 
                e.Graphics.DrawImage(_image, _position);
            }
            base.OnPaint(e);
        }
    }
