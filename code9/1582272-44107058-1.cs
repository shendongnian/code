    {
                conn.Open();
                using (var cmmand = new OleDbCommand("UPDATE tbl_voter SET VotingStatus=? WHERE VoterID=?",conn)) {
                cmmand.Parameters.AddWithValue("?", 1);
                cmmand.Parameters.AddWithValue("?", Program.VoterID);
                cmmand.ExecuteNonQuery();
           }
           conn.Close();
    }
