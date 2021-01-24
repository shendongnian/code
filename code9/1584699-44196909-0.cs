    using(var ctx = LinqExtensions.GetDataContext<MyDataContext>("MyDB"))
    {
    
    var memoD = ctx.DataContext.MemoEntities.Where(p=>p.VoucherNo == det.VoucherReferenceNumber).FirstOrDefault();
    
    if(memoD != null)
    {
    
    memoD.VoucherNo = String.Empty;
    ctx.DataContext.MemoEntities.AddOrUpdate(memoD);
    ctx.DataContext.SubmitChanges();
    
    }
    
    }
