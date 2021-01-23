     private void StarttextBox_GotFocus(object sender, RoutedEventArgs e)
            {
                Mouse.Capture(StarttextBox);
                Point mouseCoord = MouseHelper.GetMousePositionWindowsForms();
                // Or if you choose the other way :
                //Point mouseCoord = GetMousePosition();
                StarttextBox.Text = string.Format(" x {0} , y {1}", mouseCoord.X, mouseCoord .Y);
            }
