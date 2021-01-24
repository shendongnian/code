            // Get the protected OnMouseDown method via reflection.
            var textBoxBaseType = typeof(TextBoxBase);
            var onMouseDownMethod = textBoxBaseType.GetMethod("OnMouseDown", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            System.Diagnostics.Debug.Assert(onMouseDownMethod != null);
            Point mousePoint = Mouse.GetPosition(txtBox);
            var mea = new MouseButtonEventArgs(Mouse.PrimaryDevice, Environment.TickCount, MouseButton.Left);
            mea.RoutedEvent = e.RoutedEvent;    // Where e = the EventArgs parameter passed on to this method
            txtBox.SelectionLength = 0;
            onMouseDownMethod.Invoke(txtBox, new[] { mea });
