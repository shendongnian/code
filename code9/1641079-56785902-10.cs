    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    namespace WPFTestControlMoveMouse
    {
        public class MyLabel : Label
        {
            private Point _positionInBlock;
            protected override void OnMouseDown(MouseButtonEventArgs e)
            {
                // when the mouse is down, get the position within the current control. (so the control top/left doesn't move to the mouse position)
                _positionInBlock = Mouse.GetPosition(this);
                // capture the mouse (so the mouse move events are still triggered (even when the mouse is not above the control)
                this.CaptureMouse();
            }
            protected override void OnMouseMove(MouseEventArgs e)
            {
                // if the mouse is captured. you are moving it. (there is your 'real' boolean)
                if (this.IsMouseCaptured)
                {
                    // get the parent container
                    var container = VisualTreeHelper.GetParent(this) as UIElement;
                    // get the position within the container
                    var mousePosition = e.GetPosition(container);
                    // move the usercontrol.
                    this.RenderTransform = new TranslateTransform(mousePosition.X - _positionInBlock.X, mousePosition.Y - _positionInBlock.Y);
                }
            }
            protected override void OnMouseUp(MouseButtonEventArgs e)
            {
                // release this control.
                this.ReleaseMouseCapture();
            }
        }
    }
