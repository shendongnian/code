    public partial class DragableObject : UserControl
    {
        public DragableObject()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += new MouseButtonEventHandler(DragableObject_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(DragableObject_MouseLeftButtonUp);
            this.MouseMove += new MouseEventHandler(DragableObject_MouseMove);
        }
        protected bool isDragging;
        private Point clickPosition;
        private void DragableObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            var draggableControl = sender as UserControl;
            clickPosition = e.GetPosition(this.Parent as UIElement);
            draggableControl.CaptureMouse();
        }
        private void DragableObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            var draggable = sender as UserControl;
            draggable.ReleaseMouseCapture();
        }
        private void DragableObject_MouseMove(object sender, MouseEventArgs e)
        {
            var draggableControl = sender as UserControl;
            if (isDragging && draggableControl != null)
            {
                Point currentPosition = e.GetPosition(this.Parent as UIElement);
                var transform = draggableControl.RenderTransform as TranslateTransform;
                if (transform == null)
                {
                    transform = new TranslateTransform();
                    draggableControl.RenderTransform = transform;
                }
                transform.X = snapPosition(currentPosition.X - clickPosition.X, 10);
                transform.Y = snapPosition(currentPosition.Y - clickPosition.Y, 10);
            }
        }
        private double snapPosition(double position, double gridSize)
        {
            return (Math.Truncate(position / gridSize) * gridSize);
        }
    }
