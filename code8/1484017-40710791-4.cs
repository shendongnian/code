    var customerlist = from s in db.Subject
                       let sc = s.SubjectContent
                       select new SubjectOverviewViewModel
                       {
                           NeptunId = sc.NeptunId,
                           TaAdatok = sc.TaAdatok,
                           TaFoAdatok = sc.TaFoAdatok,
                           IrodalomLista = sc.IrodalomLista,
                           TaKurzusok = sc.TaKurzusok
                       };
