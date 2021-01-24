     con.Open();
            string selectSQLR = "SELECT Room_Number FROM Reservation where Reservation_ID > 0";
            SqlCommand cmdR = new SqlCommand(selectSQLR, con);
            SqlDataReader rdR;
            rdR = cmdR.ExecuteReader();
              while (rdR.Read())
                {
                    string RoomNumber = rdR.GetString(0);
                    cbRoomNumber.Items.Remove(RoomNumber);
                }
            rdR.Close();
            con.Close();
