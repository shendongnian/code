    ....
    using (SqlCommand myComm = new SqlCommand("FUELINSERT", mySqlConn))
    {
        myComm.CommandType = CommandType.StoredProcedure;
        myComm.Parameters.Add("@FUELDATE", SqlDbType.DateTime).Value = myAddFuel.FuelDate();
        myFuelId = Convert.ToInt32(myComm.ExecuteScalar());
    }
    ....
