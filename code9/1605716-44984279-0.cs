    var allPaying = from pay in Entities.Pays
                    join prc in Entities.Processingss on pay.IDCalculation equals cal.IDCalculation
                    join mbr in Entities.Members on pay.IDMember equals mbr.IDMember
                    join d in Entities.PayDetails on pay.IDMember equals d.ID into details
                    where pay.IDMember == IDMember
                    orderby prc.DateFrom descending
                    select new StructuredResult()
                    {
                        Pay = pay,
                        Processing = prc,
                        Member = mbr,
                        PayDetails = details
                    };
