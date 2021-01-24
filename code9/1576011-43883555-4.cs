    protected void Page_Load(object sender, EventArgs e)
    {
        cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = "SELECT BicycleType FROM TourDisplay ORDER BY TDateTime";
        dtr = cmd.ExecuteReader();
        
        // Again, I'd rethink your design, but if you're just playing
        // around this should be fine
        int count = 0;
        while (dtr.Read())
        {
            switch (count)
            {
                case 0:
                    TBBicycleType.Text = dtr.GetString(0);
                    break;
                case 1:
                    TBBicycleType2.Text = dtr.GetString(0);
                    break;
                // Add whatever you want to do with the third one here
                // case 2:
                //     TBBicycleType3.Text = dtr.GetString(0);
                //     break;
             }
            count++;
        }     
    }
