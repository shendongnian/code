        One of the way in which you can do this this to analyze the form screen size.
        This is the working example:
        
        	if (System.Windows.Forms.Screen.AllScreens.Length == 2 &&
        					System.Windows.Forms.Screen.AllScreens[0].WorkingArea.Width == System.Windows.Forms.Screen.AllScreens[1].WorkingArea.Width) {
        				// dual-display logic
        				System.Drawing.Rectangle sl = System.Windows.Forms.Screen.AllScreens[0].WorkingArea;
        				System.Drawing.Rectangle sr = System.Windows.Forms.Screen.AllScreens[1].WorkingArea;
        				Application.Current.MainWindow.Left = sl.Left;
        				Application.Current.MainWindow.Top = sl.Top;
        				Application.Current.MainWindow.Width = sr.Width + sl.Width;
          				Application.Current.MainWindow.Height = sl.Height;
    } else {
    				// single-display logic
    				System.Drawing.Rectangle s = System.Windows.Forms.Screen.AllScreens[0].WorkingArea;
    				Application.Current.MainWindow.Left = s.Left; Application.Current.MainWindow.Top = s.Top; Application.Current.MainWindow.Width = (s.Width / 2); Application.Current.MainWindow.Height = s.Height;
    }
