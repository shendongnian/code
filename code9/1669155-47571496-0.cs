    public static class WipCommesseListExtensions 
    {
        public static WipCommesseList ToWipCommesseList(this IEnumerable<WipCommesse> source) 
        {
            var list = new WipCommesseList();
            foreach (var item in source)
            {
                list.Add(item);
            }
        }
    }
