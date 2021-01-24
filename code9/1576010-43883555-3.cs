    protected void Page_Load(object sender, EventArgs e)
    {
        cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = "SELECT BicycleType FROM TourDisplay ORDER BY TDateTime";
        dtr = cmd.ExecuteReader();
        bool temp = false;
        
        // Added this variable.  name it anything you like.
        bool isFirstItem = true;
        while (dtr.Read())
        {
            // After the first loop iteration, isFirstItem will be set to false
            if (isFirstItem)
            {
                TBBicycleType.Text = dtr.GetString(0);
                isFirstItem = false;
            }
            // All consequent iterations of the loop will set the second 
            // item's 'Text' property.  So if you have only two rows, it 
            // will be the second row.  If you have 20 rows, it will be the 20th row.
            else
                TBBicycleType2.Text = dtr.GetString(0);
            temp = true;
        }     
    }
