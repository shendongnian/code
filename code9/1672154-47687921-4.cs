    public class MyService
    {
        public IEnumerable<PriceList> GetPriceList(Expression<Func<MyEntity, bool>> predicate)
        {
            var data = _context.MyEntity.Where(predicate).ToList();
            foreach (var item in data)
            {
                var dto = new PriceList {...}
                yield return dto;
            }        
        }
    }
