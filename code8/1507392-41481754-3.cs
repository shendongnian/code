    public partial class MainWindow : Window
    {
        private double startX;
        public MainWindow()
        {
            InitializeComponent();
            startX = translateTransform.X;
            CompositionTarget.Rendering += RollWheel;
        }
        private void RollWheel(object sender, EventArgs e)
        {
            translateTransform.X += 1.0; // calculate appropriate time-dependent value here
            rotateTransform.Angle = (translateTransform.X - startX) / rotateEllipse.RadiusX
                                  * 360 / Math.PI;
        }
    }
