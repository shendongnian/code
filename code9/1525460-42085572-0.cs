    PagedView.Context.PERSOON
                     .Join(PagedView.Context.VERHURINGEN, 
                           persoon => persoon.ComputerNr,
                           verhuring => verhuring.PersoonsID,
                           (persoon, verhuring) => new {persoon, verhuring})
                     .Join(PagedView.Context.EENHEID,
                           @t => @t.verhuring.Eenheid,
                           eenheid => eenheid.ComputerNr,
                           (@t, eenheid) => new PersoonDTO
                           {
                               ComputerNr = @t.persoon.ComputerNr,
                               FAMILIENAAM = @t.persoon.FAMILIENAAM,
                               VOORNAAM = @t.persoon.VOORNAAM,
                               NAAM = @t.persoon.NAAM,
                               ADRES = @t.persoon.ADRES,
                               Een = eenheid
                           })
                     .AsEnumerable()
                     .OrderBy(p => p.Een.PiramideId)
                     .ToList();
