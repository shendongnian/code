        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + ("paresh.csv") + "\"");
        HttpContext.Current.Response.ContentType = "application/octet-stream";
        con.Open();
        SqlCommand cmd = new SqlCommand("select top 1000000 from temp_paresh", con);
        var sb = new StringBuilder();
        using (SqlDataReader sdr = cmd.ExecuteReader())
        {
            string csvseperator = ";";
            // this is no good unless you are going to write all fields to the output stream.
            //for (int i = 0; i < sdr.FieldCount; i++)
            //{
            //    HttpContext.Current.Response.Write(sdr.GetName(i));
            //    if (i < sdr.FieldCount - 1)
            //        HttpContext.Current.Response.Write(csvseperator);
            //}
            //HttpContext.Current.Response.Write("\n");
            HttpContext.Current.Response.Write("rowid;rowname;rcount\n");
            // You also need to escape your data if it contains a ";"
            while (sdr.Read())
            {
                HttpContext.Current.Response.Write(Convert.ToString(sdr["rowid"]));
                HttpContext.Current.Response.Write(csvseperator);
                HttpContext.Current.Response.Write(Convert.ToString(sdr["rowname"]));
                HttpContext.Current.Response.Write(csvseperator);
                HttpContext.Current.Response.Write(Convert.ToString(sdr["rcount"]));
                HttpContext.Current.Response.Write("\n");
            }
        }
        con.Close();
