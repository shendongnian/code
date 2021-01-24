    public TListContainer GetSingleLog<TListContainer, TItem>(int id)
        where TListContainer : IListContainer<TItem>
    {
        var json = (from j in context.TbHistoryLog where j.Id == logId select j.ObjectJson).First();
        var lists = context.TbHistoryLog_Lists.Where(x => x.LogId == logId).Select(x => x.ListJson);
    
        var log = AuditHelper.DeserializeObject<TListContainer>(json);
    
        var list = lists.SelectMany(j => AuditHelper.DeserializeObject<List<TItem>>(j)).ToList();
        
        log.SetList(list);
 
        return log;
    }
