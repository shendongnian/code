    public class ProductData
    {
        public int qid { get; set; }
        public string vendorname { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public List<InitialInfo> productInfo { get; set; }
    }
     
    public class InitialInfo
    {
        public int qid { get; set; }    
        public int productid { get; set; }
        public string productname { get; set; }
        public string productprice { get; set; } 
    }
     public static void save(int qid, string vendorname, DateTime from, DateTime to, ProductInfo[] products2)
        {
    
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
    
                NpgsqlTransaction myTrans = conn.BeginTransaction();
    
    
                try {
    
                using (NpgsqlCommand cmd = new NpgsqlCommand("insert into public.quotation2(qid, vendorname, from_date, to_date)"
                                       + " values (@qid, @vendorname, @from, @to);", conn, myTrans))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@qid", qid);
                    cmd.Parameters.AddWithValue("@vendorname", vendorname);
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    cmd.ExecuteNonQuery();
                }
                using (NpgsqlCommand cmd1 = new NpgsqlCommand("insert into quotation_details2(qid,productid,productprice) values(@qid,@productid,@productprice)"
                                                           , conn, myTrans)) 
                {
                    cmd1.CommandType = CommandType.Text;
    
                    cmd1.Parameters.Add(new NpgsqlParameter("@productid", NpgsqlDbType.Integer));
                    cmd1.Parameters.Add(new NpgsqlParameter("@qid", qid));
                    cmd1.Parameters.Add(new NpgsqlParameter("@productprice", NpgsqlDbType.Numeric));
                        for (int i = 0; i < products2.Length; i++)
                        {
                            var pID = 0; var pPrice = "";
                            pID = products2[i].productid;
                            pPrice = products2[i].productprice;
                            cmd1.Parameters[0].Value = pID;
                            cmd1.Parameters[2].Value = pPrice;
                        NpgsqlDbType.Json.ToString()).Value = products2[i].productid.ToString();
                          NpgsqlDbType.Json.ToString()).Value = products2[i].productprice.ToString();
                            cmd1.ExecuteNonQuery();
                        }
                    }
                    myTrans.Commit();
                    Console.WriteLine("records are written to database.");
                }
                catch (NpgsqlException e)
                {
                    myTrans.Rollback();
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Neither record was written to database.");
                }
                finally
                {
                    conn.Close();
                }
            }}
