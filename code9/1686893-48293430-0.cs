            //Yep, working
            System.Windows.Media.Color color1 = (System.Windows.Media.Color)Application.Current.Resources["Color_001"];
            //Works too
            System.Windows.Media.Color? color2 = Application.Current.Resources["Color_001"] as System.Windows.Media.Color?;
            //InvalidCastException
            System.Drawing.Color color3 = (System.Drawing.Color)Application.Current.Resources["Color_001"];
