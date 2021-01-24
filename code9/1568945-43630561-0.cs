    traçabilitérepository = new TraçabilitéDemandeRepository(db);
    
                var listdemandes = (from d in db.Demande_Gabarit
                                    join t in db.Traçabilité_Demande_Gabarit
                                        on d.id_demande equals t.iddemande into ThisList
                                    from t in ThisList.DefaultIfEmpty()
                                    orderby t.idEtatD descending
    
                                    select new
                                    {
                                        id_demande = d.id_demande,
                                        NumDemande = d.NumDemande,
                                        Emetteur = d.Emetteur,
                                        Date = d.Date,
                                        Ligne = d.Ligne.designation,
                                        Etat = t.Etat_Demande_Gabarit.EtatDemande,
                                        idEtatD = XXXX
                                    }).ToList().Select(x => new DemandeViewModel()
                                    {
                                        NumDemande = x.NumDemande,
                                        Emetteur = x.Emetteur,
                                        Date = x.Date,
                                        designation = x.Ligne,
                                        EtatDemande = x.Etat,
                                        id_demande = x.id_demande
                                    });
