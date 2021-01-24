    protected void bt_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            String[] information = btn.Tag.ToString().Split('|');
            String present = "Namn: " + information[0]
                            + "\nDeviceID: " + information[1]
                            + "\nSenast uppe: " + information[2]
                            + "\nStatus: " + information[3]
                            + "\nEmail: " + information[4]
                            + "\nTW-ID: " + information[5];
            MessageBox.Show(present);
            //DO THE THINGS WITH THE INFORMATION                
        }
