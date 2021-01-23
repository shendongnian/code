            int lastScreen = System.Windows.Forms.Screen.AllScreens.Length - 1;
            System.Windows.Forms.Screen scr = System.Windows.Forms.Screen.AllScreens[lastScreen];
            System.Windows.Forms.Form f = new System.Windows.Forms.Form();
            f.Location = scr.WorkingArea.Location;
            f.Show();
