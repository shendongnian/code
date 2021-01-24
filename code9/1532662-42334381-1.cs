    public static class ListExtensions
    {
        public static List<Object> ToObjectList<T>(this List<T> list) where T : class
        {
            var objectList = new List<object>();
            list.ForEach(t => objectList.Add(t));
            return objectList;
        }
    }
    List<object> Search(int i)
        {
            if (i == 0)
            {
                return new List<Album>().ToObjectList();
            }
            else
            {
                return new List<Article>().ToObjectList();
            }          
        }
