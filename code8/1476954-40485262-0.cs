    foreach (var liability in property.Haeftelse)
                            {
                                if (liability.AttachDocument)
                                {
                                    var existingDoc = db.Dokument.Find(liability.DokumentIdentifikator, liability.DokumentRevisionNummer);
    }
