    class Program
        {
        static void Main()
        {
            var myResult = GetChains(1, 1);
            foreach (var result in myResult)
            {
                result.ChainDesc = GetChainDetails(result.ChainID);
            }
            //you can use either foreach or linq
            //var m = myResult.Select(result => result = new Y { ChainID = result.ChainID, ChainDesc = GetChainDetails(result.ChainDesc) });
        }
        public static IEnumerable<Y> GetChains(int actGroupid, int dispid)
        {
            var Chains = new List<X>();
            var query = from c in Chains                                              
                        where c.Property1 == actGroupid && c.Property2 == dispid
                        select new Y
                        {
                            ChainID = c.ChainID,
                            ChainDesc =  @"<span data-toggle=""tooltip"" title =""" + c.MyListToolTipText + @""">" + c.ChainID + "</span>"
                        };            
            return query.ToList<Y>();
        }
        public static string GetChainDetails(string chainID)
        {
            string sStep = null;
            var chainDetailList = from c in db.Chains_Detail
                                  where c.chainID == chainID
                                  orderby c.Order
                                  select new
                                  {
                                      Order = c.Order,
                                      Step = c.Step
                                  };
            foreach (var oItem in chainDetailList.ToList())
            {
                sStep = sStep + "\n" + oItem.Order + ": " + oItem.Step;
            }
            return sStep;
        }
    }   
