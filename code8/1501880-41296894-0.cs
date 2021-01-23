    public void GetDropDownList()
    {
    //Pass your data base connection string here 
    using (SqlConnection c = new SqlConnection(cString))
    //Pass your SQL Query and above created SqlConnection object  "c"
    using (SqlCommand cmd = new SqlCommand("SELECT Column1 FROM Table", c))
    {
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
             DropDownList.Add(rdr["Column1"].ToString())
           
            }
        }
    }
    }
