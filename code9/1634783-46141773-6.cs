    public void GetSingleLog<TJCls, TListObj>(int logId, out TJCls log, Expression<Func<TJCls, List<TListObj>>> listSetter)
    {
        var json = (from j in context.TbHistoryLog where j.Id == logId select j.ObjectJson).First();
        var lists = context.TbHistoryLog_Lists.Where(x => x.LogId == logId).Select(x => x.ListJson);
    
        log = AuditHelper.DeserializeObject<TListContainer>(json);
    
        var list = lists.SelectMany(j => AuditHelper.DeserializeObject<List<TListObj>>(j)).ToList();
    
        var property = (listSetter.Body as MemberExpression)?.Member as PropertyInfo;
        if (property == null) throw new Exception("Expression is not a reference to a property");
        property.SetValue(log, list, null);
    }
