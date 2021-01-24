    public static List<test> GetTestLists(DataSet ds)
    {
        var allLists = new Dictionary<int, List<test>>();
        // reverse loop necessary for efficient algorithm
        for (int i = ds.Tables.Count -1; i >= 0; i--)
        {
            List<test> childList;
            bool hasChildren = allLists.TryGetValue(i + 1, out childList);
            var testList = new List<test>();
            DataTable tbl = ds.Tables[i];
            foreach (DataRow row in tbl.Rows)
            {
                var t = new test
                {
                    id = row.Field<int>("Id"),
                    name = row.Field<int>("name") // int for name ??
                };
                if (hasChildren)
                    t.LstTest = childList;
                testList.Add(t);
            }
            allLists.Add(i, testList);
        }
        return allLists.TryGetValue(0, out List<test> parentList) ? parentList : null;
    }
