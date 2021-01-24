        var dtos =
            from co in context.Coworkers
            join du in context.Duties on co.CPR equals du.CPR
            where du.Projektname == projektname
            select new CoWorkerDTO {
               Fornavn = co.Fornavn,
               Efternavn = co.Efternavn,
               Alder = co.Alder,
               CPR = co.CPR,
               AntalTimer = co.AntalTimer
            };
        return dtos.ToList();
