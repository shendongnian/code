    TransactionDto resultAlias = null;
    var results = session.QueryOver<TransactionTable>(() => transactionAlias)
                    .Left.JoinAlias(pr => pr.UserFrom, () => usersFromAlias)
                    .Left.JoinAlias(pr => pr.UserTo, () => usersToAlias)
                    .Left.JoinAlias(pr => pr.GatewayTable, () => gatewayAlias)
                    .SelectList(list => list
                        .Select(pr => pr.TransactionId).WithAlias(() => resultAlias.TransactionId)
                        .Select(pr => pr.Amount).WithAlias(() => resultAlias.Amount)
                        .Select(pr => pr.Reason).WithAlias(() => resultAlias.Reason)
                        .Select(pr => pr.TransactionDatetime).WithAlias(() => resultAlias.TransactionDatetime)
                        .Select(pr => pr.GatewayTableId).WithAlias(() => resultAlias.GatewayTableId)
                        .Select(Projections.Conditional(
                            Restrictions.Eq(
                                Projections.Property(() => transactionAlias.UserFromId), 0),
                            Projections.Constant("Paypal"),
                            Projections.Property(() => usersFromAlias.FullName)
                        )).WithAlias(() => resultAlias.UserFromName)
                        .Select(Projections.Conditional(
                            Restrictions.Eq(
                                Projections.Property(() => transactionAlias.UserToId), 0),
                            Projections.Constant("Paypal"),
                            Projections.Property(() => usersToAlias.FullName)
                        )).WithAlias(() => resultAlias.UserToName))
                    .TransformUsing(Transformers.AliasToBean<TransactionDto>())
                    .List<TransactionDto>();
