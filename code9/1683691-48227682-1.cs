    foreach (var postedModel in tbMapViewModel.TBMapBalancesList)
    {
        var dbModel = _context.TBMapBalances.SingleOrDefault(p => p.TbMapId == postedModel.TbMapId);
        if (dbModel != null)
        {
            dbModel.UniqueAdp = postedModel.UniqueAdp;
        }
    }
    await _context.SaveChangesAsync();
