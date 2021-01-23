     var sumFundSpreadDuration = raptorDS.Tables[RaptorTable.DurationContribBySector].AsEnumerable().Where(r =>
                                                 r.Field<string>(RaptorColumns.FundCode) == fundDescriptionColumn &&
                                                 r.Field<string>(RaptorColumns.Component) == Component.B8_DURATION_CONTRIBUTION_BY_SECTOR &&
                                                 r.Field<string>(RaptorColumns.Sector) == "Spread Duration--IR Swap")
                                                 .Select(s => s.Field<double?>(RaptorColumns.FundSpreadDurationContribution)).FirstOrDefault();
