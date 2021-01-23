            SqlCommand cmd;
            SqlConnection conn;
            SqlDataReader dr;
            string FileName = "";
            string FileType = "";
            //Get FileName And Type
            cmd = new SqlCommand("SELECT FileName, FileType FROM YourTable WHERE YourCondition", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FileName = dr["FileName"].ToString();
                FileType = dr["FileType"].ToString();
            }
            //Load the varbinary into a datatable
            cmd = new SqlCommand("SELECT FileData FROM YourTable WHERE YourCondition", conn);
            DataTable dt = new DataTable();
            dr = cmd.ExecuteReader();
            dt.Load(dr);    
            //Extract the rows into a byte array
            byte[] stream = (byte[])dt.Rows[0][0];
            //Re-create the file from the byte array
            File.WriteAllBytes(@"C:\Temp\" + FileName + FileType, stream);
