    public List<TOrderPosition> GetOrderPositionOfOrder<TOrderPosition>(long? id)
        where TOrderPosition : IOrderPosition<IOrder, IArticle, TOrderPosition>
    {
        ...
    }
