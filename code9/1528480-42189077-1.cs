    public static IQueryable<MainTable> tblInfo(MyDataContext dx, int id)
    {
        return dx.MainTables.Where(t => t.id == id);
    }
    ...
    using (var dx = new MyDataContext())
    {
        int count = tblInfo(dx, 42).SelectMany(t => t.Related_Huge_Table_Datas).Count();
    }
