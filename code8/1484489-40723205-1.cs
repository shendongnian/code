     public void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                var myControl = (YourControlType)sender;                         
                var position = e.GetPosition(myControl);
                var controlPosition= myControl.PointToScreen(position);
            }
