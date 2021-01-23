           if (DateTime.Now.ToUniversalTime().AddHours(5).AddMinutes(30).Hour < 12)
            {
                lblGreeting.Text = "Good Morning";
                lblDate.Text = Convert.ToString(DateTime.Now);
            }
            else if (DateTime.Now.ToUniversalTime().AddHours(5).AddMinutes(30).Hour < 17)
            {
                lblGreeting.Text = "Good Afternoon";
                lblDate.Text = Convert.ToString(DateTime.Now);
            }
            else
            {
                lblGreeting.Text = "Good Evening";
                lblDate.Text = Convert.ToString(DateTime.Now);
            }
