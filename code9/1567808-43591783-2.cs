    // This uses a Connection pool, so you don't need to reuse the same SqlConnection
    using (SqlConnection con = new SqlConnection(...))
    {        
        using (SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select [car_rental_price] from cars where id = @Id";
            var idParam = new SqlParameter("@Id");
            idParam.Value = id;
            cmd.Parameters.Add(idParam);
            con.Open();
            using (var reader = cmd.ExcecuteReader()) 
            {
                reader.Read();
                lblRentalPrice.Text = reader.GetInt32(0).ToString();
                lblCarID.Text = id.ToString();} 
            }
        }
     }
