            mySqlConn.Open();
            using (SqlCommand myComm = new SqlCommand("FUELINSERT", mySqlConn))
            {
                myComm.CommandType = CommandType.StoredProcedure;
				myComm.CommandText = "Exec YourProcedure @FUELDATE,@FUELID";
                myComm.Parameters.Add("@FUELDATE", SqlDbType.DateTime).Value = myAddFuel.FuelDate();
                myComm.Parameters.Add("@FUELID", SqlDbType.Int).Direction = ParameterDirection.Output;
                myFuelId = Convert.ToInt32(myComm.Parameters["@FUELID"].Value);
				myComm.ExecuteNonQuery();
                mySqlConn.Close();
            }
