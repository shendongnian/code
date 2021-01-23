    public void MarkAsNonFreshSample(string barcode, int devID)
    {
        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "DELETE FROM results WHERE barcode=@barcode AND devID=@devID";
                command.Parameters.AddWithValue("barcode", barcode);
                command.Parameters.AddWithValue("devID", devID);
                command.ExecuteNonQuery();
            }
        } 
    }
