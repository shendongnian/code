    public IPagedList<listData> getdata(int? Page, int? pageIndex)
    {
       ...
       return data.OrderByDescending(x => x.OnSave).ToPagedList(Page ?? 1, pageIndex ?? 10);
    }
