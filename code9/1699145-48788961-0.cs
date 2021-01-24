    var results = session.QueryOver<TransactionTable>(() => transactionAlias)
                    .Left.JoinAlias(pr => pr.UserFrom, () => usersFromAlias)
                    .Left.JoinAlias(pr => pr.UserTo, () => usersToAlias)
                    .Left.JoinAlias(pr => pr.GatewayTable, () => gatewayAlias)
                    .SelectList(list => list
                        .Select(pr => pr.TransactionId)
                        .Select(pr => pr.Amount)
                        .Select(pr => pr.Reason)
                        .Select(pr => pr.TransactionDatetime)
                        .Select(pr => pr.GatewayTableId)
                        .Select(Projections.Conditional(
                            Restrictions.Eq(
                                Projections.Property(() => transactionAlias.UserFromId), 0),
                            Projections.Constant("Paypal"),
                            Projections.Property(() => usersFromAlias.FullName)
                        ))
                        .Select(Projections.Conditional(
                            Restrictions.Eq(
                                Projections.Property(() => transactionAlias.UserToId), 0),
                            Projections.Constant("Paypal"),
                            Projections.Property(() => usersToAlias.FullName)
                        )))
                    .List<object[]>();
