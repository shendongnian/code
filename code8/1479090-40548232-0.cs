    DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
    DateTime utcTime = serverTime.ToUniversalTime; // convert it to Utc using timezone setting of server computer
    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local
    if (localTime  < 12) {
            lblGreeting.Text = "Good Morning";
            lblDate.Text = Convert.ToString(localTime );
        } else if (localTime  < 17) {
            lblGreeting.Text = "Good Afternoon";
            lblDate.Text = Convert.ToString(localTime );
        } else {
            lblGreeting.Text = "Good Evening";
            lblDate.Text = Convert.ToString(localTime );
        }
