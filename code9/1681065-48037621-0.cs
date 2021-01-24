    liste_rep.GroupBy(l => l.Nom)
                        .Select(cl => new Repere
                        {
                            Quantite = cl.Sum(c => c.Quantite),
                            IdAff = cl.First().IdAff,
                            ID = 0,
                            ListeOperations = cl.First().ListeOperations,
                            StatutOperations = cl
    						                   .Select(x=>x.StatutOperations)
    										   .Aggregate((x,y)=> x.Zip(y,(p,q)=>p+q).ToList());
                        }).ToList();
