                IEnumerable<InstrumentDetails> instrumentdetails = (from p in NemcDb.tblPulls
                                                                join
                                                                pi in NemcDb.tblPullInstruments
                                                                on
                                                                p.PullId equals pi.PullId
                                                                join
                                                                i in NemcDb.tblInstruments
                                                                on
                                                                pi.InstrumentCode equals i.InstrumentCode
                                                                select new InstrumentDetails
                                                                {
                                                                    PullNo = p.PullNo.Value,
                                                                    InstrumentType = i.Description,
                                                                    New = pi.NewQuantity,
                                                                    LN = pi.LNQuantity,
                                                                    PR = pi.UsedQuantity,
                                                                    Any = pi.AnyQuantity
                                                                }).Where(i => i.PullNo.ToString() == item).ToList();
        }
