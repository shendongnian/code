    int bikeID = 0;
    if(!Int32.TryParse(txtBikeIdRent.Text, out bikeID)
    {
         MessageBox.Show("Invalid number");
         return;
    }
    DateTime returnDate;
    if(!DateTime.TryParse(txtToBeReturned.Text , out returnDate)
    {
         MessageBox.Show("Invalid date");
         return;
    }
    string myConnection = ".....";
    string Query = @"UPDATE bikerentaldb.tblbikes 
        SET status='Rented', renteddate=NOW(),
            assignedreturndate=@date
            WHERE bikeID=@id"; 
    using(MySqlConnection myConn = new MySqlConnection(myConnection))
    using(MySqlCommand cmd = new MySqlCommand(Query, myConn))
    {
         myConn.Open();
         cmd.Parameters.Add("@date", MySqlDbType.Date).Value = returnDate;
         cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = bikeID;
         int rowUpdated = cmd.ExecuteNonQuery();
         if(rowUpdated > 0)
             MessageBox.Show("Record updated");
         else
             MessageBox.Show("No record match");
    }
