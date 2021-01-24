     private void ButtonDashboard_Click(object sender, EventArgs e)
        {
            comeuser.Close();
            comeuser = null;
            comereports.Close();
            comereports = null;
            comeabout.Close();
            comeabout = null;
            if (comedash == null)
            {
                comedash = new DashBoard();
            }
                comedash.TopLevel = false;
                comedash.Dock = DockStyle.Fill;
                comedash.Dock = DockStyle.Fill;
                comedash.Show();
                MainEventPanel.Controls.Add(comedash);
          
            
            ButtonDashboard.Textcolor = Color.FromArgb(222, 120, 53);
            ButtonUser.Textcolor = Color.Gainsboro;
            ButtonReports.Textcolor = Color.Gainsboro;
            ButtonAbout.Textcolor = Color.Gainsboro;
            HeaderMain.Text = "Dashboard";
        
          
                
           
        }
    private void ButtonUser_Click(object sender, EventArgs e)
        {
            if (comedash != null)
            {
                comedash.Close();
            }
            if (comereports!=null)
            {
                comereports.Close();
               
            }
            comereports = null;
            if (comeabout != null)
            {
                comeabout.Close();
            }
            comeabout = null;
            if (comeuser==null)
            {
                comeuser = new UserControl();
            }
                comeuser.TopLevel = false;
                comeuser.Dock = DockStyle.Fill;
                comeuser.Dock = DockStyle.Fill;
                comeuser.Show();
                MainEventPanel.Controls.Add(comeuser);
            
            
              
             
            
          
         
            ButtonUser.Textcolor = Color.FromArgb(222, 120, 53);
            ButtonDashboard.Textcolor = Color.Gainsboro;
            ButtonReports.Textcolor = Color.Gainsboro;
            ButtonAbout.Textcolor = Color.Gainsboro;
            HeaderMain.Text = "User Control";
        }
        private void ButtonReports_Click(object sender, EventArgs e)
        {
            comedash.Close();
            comedash = null;
            comeuser.Close();
            comeuser = null;
            comeabout.Close();
            comeabout = null;
            if (comeabout==null)
            {
                comeabout = new About();
            }
    
            comereports.TopLevel = false;
            comereports.Dock = DockStyle.Fill;
            comereports.Dock = DockStyle.Fill;
            comereports.Show();
            MainEventPanel.Controls.Add(comereports);
            ButtonReports.Textcolor = Color.FromArgb(222, 120, 53);
            ButtonUser.Textcolor = Color.Gainsboro;
            ButtonDashboard.Textcolor = Color.Gainsboro;
            ButtonAbout.Textcolor = Color.Gainsboro;
            HeaderMain.Text = "Reports";
        }
