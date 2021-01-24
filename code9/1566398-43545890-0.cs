    using System.Linq;
    using NHibernate.Linq;
    ...
    var orderEventsIdsQuery = Session.Query<OrderEvent>()
        .Where(oe => orderIds.Contains(oe.OrderRevision.Order.Id))
        .GroupBy(oe => oe.OrderRevision.Order.SourceOrderIdentifier,
            (soi, oes) => oes.Max(oe => oe.Id));
    var result = Session.Query<OrderEvent>()
        .Where(oe => orderEventsIdsQuery.Contains(oe.Id))
        .ToDictionary(oe => oe.OrderRevision.Order.SourceOrderIdentifier,
            oe => oe.TradedQuantity);
