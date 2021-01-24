    public partial class VisualBlock : UserControl
    {
        private Point _positionInBlock;
        public VisualBlock()
        {
            InitializeComponent();
        }
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // when the mouse is down, get the position with the current control. (so the control top/left doesn't move to the mouse position)
            _positionInBlock = Mouse.GetPosition(this);
            
            // capture the mouse (so the mouse move events are still triggered (even when the mouse is not above the control)
            this.CaptureMouse();
        }
        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            // if the mouse is captured. you are moving it.
            if (this.IsMouseCaptured)
            {
                // get the parent container
                var container = VisualTreeHelper.GetParent(this) as UIElement;
                
                // get the position within the container
                var pos = e.GetPosition(container);
                
                // move the usercontrol.
                this.RenderTransform = new TranslateTransform(pos.X - _positionInBlock.X, pos.Y - _positionInBlock.Y);
            }
        }
        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // release this control.
            this.ReleaseMouseCapture();
        }
    }
