            mySqlConn.Open();
            using (SqlCommand myComm = mySqlConn.CreateCommand())
            {
                myComm.CommandType = CommandType.StoredProcedure;
				myComm.CommandText = "Exec YourProcedure @FUELDATE,@FUELID";
                myComm.Parameters.Add("@FUELDATE", SqlDbType.DateTime).Value = myAddFuel.FuelDate();
                myComm.Parameters.Add("@FUELID", SqlDbType.Int).Direction = ParameterDirection.Output;
                myFuelId = Convert.ToInt32(myComm.Parameters["@FUELID"].Value);
				int result = myComm.ExecuteNonQuery();
           
                mySqlConn.Close();
                return result;
            }
