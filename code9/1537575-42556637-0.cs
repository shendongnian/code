    public static List<string> BookmarksList(Dictionary<string, object> parent, List<string> bookmarkList)
    {
        if (parent.ContainsKey("Kids"))
        {
            IList<Dictionary<string,object>> child = parent["Kids"] as IList<Dictionary<string, object>>;
 
            foreach(Dictionary<string, object> tmpChild in child)
            {
                bookmarkList.Add(tmpChild["Title"].ToString());
                MyClass.BookmarksList(tmpChild, bookmarkList);
            }
        }
        return bookmarkList;
    }
