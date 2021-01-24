    public bool delete(DataRow rowdelete)
    {     
        using(SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "DELETE FROM DoctorTbl WHERE DoctorID = @doctorid";
            cmd.Parameters.Add("@doctorid", SqlDbType.Int).Value = Convert.ToInt32(rowdelete["DoctorId"]);
            cmd.ExecuteNonQuery();
            // Now fix the in memory table to remove the deleted row 
            DataTable dt = rowDelete.Table;
            rowDelete.Delete();
            table.AcceptChanges();
        }
    }
