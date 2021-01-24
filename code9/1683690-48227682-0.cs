    foreach (var TbListId in tbMapViewModel.TBMapBalancesList)
    {
        var getCode = _context.TBMapBalances.Where(p => p.TbMapId == TbListId.TbMapId).FirstOrDefault();
        if (getCode != null)
        {
            getCode.TbMapId = TbListId.TbMapId;
        }
    }
    try
    {
        _context.Update(tbMapViewModel.TBMapBalances);
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        throw;
    }
