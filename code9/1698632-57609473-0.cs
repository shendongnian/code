c#
public void FirstMethod()
{
    // This is returning an IQueryable
    var stockItems = _dbContext.StockItems
        .Where(st => st.IsSomething);
    SecondMethod(stockItems);
}
public void SecondMethod(IEnumerable<Stock> stockItems)
{
    var grnTrans = _dbContext.InvoiceLines
        .Where(il => stockItems.Contains(il.StockItem))
        .ToList();
}
To stop that happening I used the [approach here][1] and materialised that list before passing it the second method, by changing the call to `SecondMethod` to be `SecondMethod(stockItems.ToList()`
  [1]: https://stackoverflow.com/a/55716936/1879019
