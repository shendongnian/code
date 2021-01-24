        public partial class ItemModel
        {
            public virtual List<string> itemId { get; set; }
            public virtual List<string> itemName { get; set; }
        }
    **So your new model should be :** 
 
            public partial class ItemModel
            {
                public virtual string itemId { get; set; }
                public virtual string itemName { get; set; }
            }
            And Your **Controller Action** should be :
            public ActionResult test()
            {
                ItemModel model = new ItemModel();
                List<ItemModel> itemList = new List<ItemModel>();
                testorder to = new testorder();
                DbHandle dh = new DbHandle();
                var itemmodel = dh.searchtes('S', to);
                //Second way if not work first way
                foreach (var itemvalue in itemmodel)
                {
                    model.itemId = itemvalue.itemId;
                    model.itemName = itemvalue.itemName;
                    itemList.Add(model);
                }
                return View("test", itemList);
            }
            //your method should be 
            public List<ItemModel> searchtes(char flag, testorder to)
            {
                List<string> items = new List<string>();
                connection();
                SqlCommand cmd = new SqlCommand("SPNAME", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PstrOperationFlag", flag);
                cmd.Parameters.AddWithValue("@Pstrtestname", 'w');
                con.Open();
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                ItemModel item = new ItemModel();
                List<ItemModel> itemList = new List<ItemModel>();
                //item.itemId.Add(sdr["testId"].ToString());
                //item.itemName.Add(sdr["testname"].ToString());
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        item.itemId = sdr["testId"].ToString();
                        item.itemName = sdr["testname"].ToString();
                        itemList.Add(item);
                    }
                }
                con.Close();
                return itemList;
            }
