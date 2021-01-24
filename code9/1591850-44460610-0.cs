    myCSTotal2.AddRange(userTotals.Where(w => w.priceinfoId == priceinfoID)
                                  .Select( o => new Model.MyCSTotal2
                                   {
                                    PriceinfoID = o.priceinfoId,
                                    BillcodeID = o.billcodeid,
                                    JobTypeID = o.jobtypeID,
                                    SaleTypeID = o.saletypeID,
                                    RegratesID = o.regratesID,
                                    NatAccPerc = o.natAcctPerc,
                                    NatIgnInCommCalc = o.natIgnInCommCalc,
                                    TermLength = (int)o.termLength,
                                    Amount = o.RMR1YrTotal / 12,
                                    RuleEvaluation = 0
                                  });
