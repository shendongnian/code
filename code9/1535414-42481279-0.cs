                    var raw = await Collection.GroupAsync(
                    x => x.At >= fromDate && x.At <= toDate && valorArray.Contains(x.Valor),
                    x => x.At,
                    x => new ProductPositionKey {Valor = x.Valor, IssueNostro = x.IssueNostro},
                    g => new ProductPositionGroupItem
                    {
                        CurrencyId = g.Last().CurrencyId,
                        DescriptionCombo = g.Last().DescriptionCombo,
                        Id = g.Last().Id,
                        IssueNostro = g.Last().IssueNostro,
                        NominalInCertificateCurrency = g.Last().NominalInCertificateCurrency,
                        NominalInChf = g.Last().NominalInChf,
                        PaymentDate = g.Last().PaymentDate,
                        Position = g.Last().Position,
                        PositionFirstDate = g.First().At,
                        PositionLastDate = g.Last().At,
                        Price = g.Last().Price,
                        ProductName = g.Last().ProductName,
                        RedemptionDate = g.Last().RedemptionDate,
                        Source = g.Last().Source,
                        TimeStamp = g.Last().TimeStamp,
                        Valor = g.Last().Valor
                    });
