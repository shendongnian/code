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
                if (list.Contains("Soups"))
                    result  = result| ItemStorage.Soups;
                if (list.Contains("Burger"))
                    result = result | ItemStorage.Burger;
                if (list.Contains("Drinks"))
                    result = result | ItemStorage.Drinks;
                if (list.Contains("Desserts"))
                    result = result | ItemStorage.Dessert;
                if (list.Contains("Cheese"))
                    result = result | ItemStorage.Cheese;
            }
            return result;
            
        }
    }
