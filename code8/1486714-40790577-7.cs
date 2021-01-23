    interface IOrderPosition<out TOrder, out TArtile, TOrderPosition>
        where TOrder : IOrder
        where TArtile : IArticle
        where TOrderPosition : IOrderPosition<TOrder, TArtile, TOrderPosition>
    {
        long? id { get; set; }
        TOrder order { get; }
        TArtile Article { get; }
        List<TOrderPosition> subPositions { get; set; }
    }
