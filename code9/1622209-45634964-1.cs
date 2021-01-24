    public class MyTestEntity
    {
        public bool IsTrue { get; set; }
        public string OrderText { get; set; }
        public int ThenOrderBy { get; set; }
    }
    var entities = new List<MyTestEntity>(new []
    {
        new MyTestEntity { IsTrue = true, OrderText = "1234", ThenOrderBy = 4321 },
        new MyTestEntity { IsTrue = true, OrderText = "000001", ThenOrderBy = 000001 },
        new MyTestEntity { IsTrue = false }
    });
    var searchPredicate = new Func<MyTestEntity, bool>(entity => entity.IsTrue);
    var orderConfig = new List<ColumnOrderConfiguration<MyTestEntity>>(new []
    {
        // first order by `OrderText` ascending
        new ColumnOrderConfiguration<MyTestEntity>
        {
            ValueSelector = entity => entity.OrderText,
            SortOrder = SortOrder.Ascending
        },
        // then order by `ThenOrderBy` descending
        new ColumnOrderConfiguration<MyTestEntity>
        {
            ValueSelector = entity => entity.ThenOrderBy,
            SortOrder = SortOrder.Descending
        }
    });
    var pageIndex = 0;
    var pageSize = 20;
    var result = entities.Prepare(searchPredicate, orderConfig, pageIndex, pageSize);
