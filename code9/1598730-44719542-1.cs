    public class MyMapArea : UserControl
    {
        public MyMapArea()
        {
        }
        /// <summary>
        /// Returns the Y position relative to ScreenTop in Pixels
        /// </summary>
        private int GetYPositionOfPopup()
        {
            Popup popup = this.popup;
            Window window;
            FrameworkElement element;
            //Walk up the ui tree
            while(1 == 1)
            {
                //Remember to check for nulls, etc...
                element = this.parent;
                if(element.GetType() == typeof(Window))
                {
                    //if you found the window set it to "window"
                    window = (window)element;
                    break;
                }
            }
            Point relativePointInWindow = popup.TransformToAncestor(window)
                                       .Transform(new Point(0, 0));
            return relativePointInWindow.Y // + System.Windows.SystemParameters.CaptionHeight;
        }
    }
