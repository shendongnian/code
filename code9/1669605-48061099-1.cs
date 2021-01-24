        public static List<ProductInfo> GetProductInfo()
        {
            List<ProductInfo> products = new List<ProductInfo>();
            DataSet ds = new DataSet();
            con = new NpgsqlConnection(connectionString);
            {
                using (var cmd = new NpgsqlCommand("select *from product1", con))
                {  
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    products.Add(new ProductInfo()
                    {
                        productcode = int.Parse(dr["productcode"].ToString()),
                        productname = dr["productname"].ToString(),
                        productprice = float.Parse(dr["productprice"].ToString()),
                        productqty = int.Parse(dr["productqty"].ToString())
                    });
            }
            return products;
        }
    public class ProductInfo
    {
        public int productcode { get; set; }
        public string productname { get; set; }
        public float productprice { get; set; }
        public int productqty { get; set; }
    }
