    using (SqlDataReader dr1 = cmd1.ExecuteReader())
            {
                if (dr1.Read())
                {
                    string countcheck;
                    countcheck = notifyIcon2.Text;
                    count = dr1[0].ToString();
                    notifyIcon2.Text = "NCT COUNT FOR COLLEAGUE IS: " + count;
                    if (countcheck == notifyIcon2.Text)
                    {
                        return;
                    }
                    else
                    {
                        notifyIcon2.BalloonTipText = "NCT COUNT FOR COLLEAGUE IS: " + count;
                        notifyIcon2.ShowBalloonTip(50000);
                    }
    
                    //pick a colored icon based on the count of the NCT cases
                    if (Convert.ToInt32(count) <= 3)
                    {
                        notifyIcon2.Icon = new Icon("C:\\BackupFromPC\\greenicon.ico");
                    }
                    else if (Convert.ToInt32(count) > 3 && Convert.ToInt32(count) <= 5)
                    {
                        notifyIcon2.Icon = new Icon("C:\\BackupFromPC\\yellowicon.ico");
    
                    }
                    else if (Convert.ToInt32(count) > 5)
                    {
                        notifyIcon2.Icon = new Icon("C:\\BackupFromPC\\redicon.ico");
                    }
                    //------------------------------                
                }
            }
