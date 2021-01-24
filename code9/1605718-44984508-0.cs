    var allPaying = (from pay in Entities.Pays
                     join prc in Entities.Processingss on pay.IDCalculation equals cal.IDCalculation
                     join mbr in Entities.Members on pay.IDMember equals mbr.IDMember
    
                     where pay.IDMember == IDMember
                     orderby prc.DateFrom descending
                     select new StructuredResult()
                     {
                         Pay = pay,
                         Processing = prc,
                         Member = mbr,
                         PayDetails = (from pd in Entities.PayDetails
                                       where pd.ID == pay.IDMember
                                       select pd).ToList())
                     }).ToList();
