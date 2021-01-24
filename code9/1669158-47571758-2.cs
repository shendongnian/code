     WipCommesseList wipGrouped = 
       new WipCommesseList(myList.GroupBy(x => new
                                {
                                    x.IdTipologia,
                                    x.NumCommessa
                                }).
                                Select(g => new WipCommesse()
                                {
                                    IdTipologia = g.Key.IdTipologia,
                                    NumCommessa = g.Key.NumCommessa,
                                    TotQtaLetta = g.Sum(i => i.QtaLanciabile)
                                }));
