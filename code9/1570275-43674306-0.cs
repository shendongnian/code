        // With Custom Parameter. pass textbox value in to date parameter
        //public int GetNextAppointmentNo(DateTime date)
        public int GetNextAppointmentNo()
        {
            string db = "Data Source=DESKTOP-R6H3RTP; Initial Catalog=TokenDB; Integrated Security=true; ";
            using (SqlConnection mycon = new SqlConnection(db))
            {
                // this query is focused on Today
                string query = @"SELECT
                              COALESCE(MAX(ANo), 0) + 1 AS AppointmentNO
                            FROM tblApointment
                            WHERE CONVERT(DATE, ADate) = CONVERT(DATE, GETDATE())";
                // With Custom Parameter
                //string query = @"SELECT
                //                COALESCE(MAX(ANo), 0) + 1 AS AppointmentNO
                //            FROM tblApointment
                //            WHERE CONVERT(DATE, ADate) = CONVERT(DATE, @ADate)";
                using (SqlCommand cmd = new SqlCommand(query, mycon))
                {
                    // if you need to add custom parameter to the query
                    // cmd.Parameters.AddWithValue("@ADate", date);
                    
                    mycon.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader.HasRows ? Convert.ToInt32(reader["AppointmentNO"].ToString()) : 1;
                    }
                }
            }
        }
