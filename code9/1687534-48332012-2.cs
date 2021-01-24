        var q1 = db.Atendimentoes
                   .Select(a => new
                                {
                                    AId = a.Id,
                                    AField = a.Field1,
                                    CId = a.CaixaTransacao.Id,
                                    CField1 = a.CaixaTransacao.Field2,
                                    CField2 = a.CaixaTransacao.Field3
                                }).ToList();
