    public class Stuff
    {
        private List<string> Items;
        private static string Connection()
        {
            return ConfigurationManager.ConnectionStrings["deliverycon"].ToString();
        }
        public bool DoStuff()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    using (SqlCommand cmd = new SqlCommand("AddNewBestellung", con))
                    {
                        cmd.Parameters.AddWithValue("@Items", (int)ConstuctEnumValueFromList(Items));
                        //other saved parameters...
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i >= 1)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                return false;
            }
        }
        private ItemStorage ConstuctEnumValueFromList(List<string> list)
        {
            var result = new ItemStorage();
            if (list.Any())
            {
                var separatedList = string.join(",", list)
                bool success = Enum.TryParse<ItemStorage>(separatedList, out result)
            }
            return result;
        }
    }
