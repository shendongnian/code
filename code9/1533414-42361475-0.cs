         return Context.p_Countries_List(userName, statusCode, statusMessage)
                  .Select(c => new Countries_List_ResultModel()
                {
                    currency = c.currency
                }).Distinct(new MyCustomComparer()).ToList();
        public class MyCustomComparer : IEqualityComparer<Countries_List_ResultModel>
        {
            public bool Equals(Countries_List_ResultModel x, Countries_List_ResultModel y)
            {
                if (x == y) return true;
                if (x == null || y == null) return false;
                return x.currency == y.currency;
            }
    
            public int GetHashCode(Countries_List_ResultModel obj)
            {
                if (obj == null) return 0;
                return obj.currency.GetHashCode();
            }
        }
