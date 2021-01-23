     public void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                var myControl = (YourControlType)sender;                         
                var controlPosition= myControl.PointToScreen(myControl);
            }
