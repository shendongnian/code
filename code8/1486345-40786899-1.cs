    namespace ScrollMenue
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private double hOff;
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void rectrechts_MouseEnter(object sender, MouseEventArgs e)
            {
                //label1.Content = "rechts";
                //scrollviewer1.LineRight();
            }
    
            private void rectlinks_MouseEnter(object sender, MouseEventArgs e)
            {
                
                //if (rectlinks.IsMouseOver == true)
                //{
                //    scrollviewer1.ScrollToHorizontalOffset(scrollviewer1.HorizontalOffset + 10);
                //    label1.Content = "links";
                //    scrollviewer1.LineLeft();
                //}
            }
    
    
            private Point scrollMousePoint;
            private bool drag;
    
            private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
            {
                scrollviewer1.ReleaseMouseCapture();
    
                if (IsMouseOverControl(BtnFoo) && !drag)
                {
                    var peer = new ButtonAutomationPeer(BtnFoo);
                    var invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
    
                    invokeProv?.Invoke();
                }
    
                drag = false;
            }
    
            private void UIElement_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                
                scrollMousePoint = e.GetPosition(scrollviewer1);
                hOff = scrollviewer1.HorizontalOffset;
    
                drag = false;
                scrollviewer1.CaptureMouse();
            }
    
            private void UIElement_OnPreviewMouseMove(object sender, MouseEventArgs e)
            {
                if (scrollviewer1.IsMouseCaptured)
                {
                    var moveTo =  scrollMousePoint.X - e.GetPosition(scrollviewer1).X;
                    
                    if (Math.Abs(moveTo ) > 1)
                    {
                        drag = true;
                        scrollviewer1.ScrollToHorizontalOffset(hOff + moveTo);
                    }
    
                    
                }
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
               MessageBox.Show("Click");
            }
    
            private bool IsMouseOverControl(UIElement control)
            {
                var mousePos = Mouse.GetPosition(control);
                var size = control.RenderSize;
    
                if (mousePos.X < 0 || mousePos.X > size.Width ||
                    mousePos.Y < 0 || mousePos.Y > size.Height)
                {
                    return false;
                }
    
                return true;
            }
        }
    }
