    interface IOrderPosition<out TOrder, out TArticle, TOrderPosition>
        where TOrder : IOrder
        where TArticle : IArticle
        where TOrderPosition : IOrderPosition<TOrder, TArticle, TOrderPosition>
    {
        long? id { get; set; }
        TOrder order { get; }
        TArticle Article { get; }
        List<TOrderPosition> subPositions { get; set; }
    }
