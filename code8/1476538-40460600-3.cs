            for (int count = 0; count < System.Windows.Forms.Screen.AllScreens.Length; count++)
            {
                System.Windows.Forms.Screen scr = System.Windows.Forms.Screen.AllScreens[count];
                System.Windows.Forms.Form f = new System.Windows.Forms.Form();
                f.Location = scr.WorkingArea.Location;
                f.StartPosition = FormStartPosition.Manual;
                Label screenNumber = new Label();
                screenNumber.Text = "You are looking at screen # " + count.ToString();
                screenNumber.AutoSize = true;
                f.Controls.Add(screenNumber);
                f.Show();
            }
