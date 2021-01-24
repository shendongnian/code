    var page = 0;
    var step = 10;
    var block = _DataEntities.<TABLE_NAME>.Skip(page * step).Take(step).Select(x => x.<COLUMN_NAME>).ToList();
    while (block.Count > 0)
    {
        foreach (var item in block)
        {
            yield return item;
        }
        page++;
        block = _DataEntities.<TABLE_NAME>.Skip(page * step).Take(step).Select(x => x.<COLUMN_NAME>).ToList();
    }
