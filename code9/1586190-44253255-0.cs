    public class ShopDB
        {
            string cs = ConfigurationManager.ConnectionStrings["ShopEntities"].ConnectionString;
    
            public List<Barang> ListAll()
            {
                List<Barang> lst = new List<Barang>();
                SqlConnection con = new SqlConnection(cs);
                //using(SqlConnection con=new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("SelectBarang", con);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
    
                    {
                        lst.Add(new Barang
                        {
                          IdBarang = Convert.ToInt32(rdr["IdBarang"]),
                          NamaBarang = rdr["NamaBarang"].ToString(),
                          Harga = Convert.ToInt32(rdr["Harga"]),
                          CategoriId = Convert.ToInt32(rdr["CategoriId"]),
                          GambarBarang = (byte[])rdr["ImageColumn"]                     
    
                    });
                    }
                    return lst;
                }
            }
