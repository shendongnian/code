    public string tampil_register(string email_supplier)
    {
        using(var con = new SqlConnection(connectionString))
        {
            using(var command = new SqlCommand("SELECT kode_supplier FROM tb_supplier WHERE email_supplier = @email_supplier", con))
            {
                command.Parameters.Add("@email_supplier", SqlDbType.VarChar).Value = email_supplier;
                con.Open();
                var hasil = command.ExecuteScalar();
                if(hasil != null && hasil != DBNull.Value)
                {
                    return hasil.ToString();
                }
            }
        }
        return ""; // in case no record was found
    }
