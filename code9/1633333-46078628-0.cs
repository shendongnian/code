    public class ListTable
    {
        private static IList<object> rolelist = new List<object>();
        public static IList<object> GetList()
        {
            return rolelist;
        }
    }
