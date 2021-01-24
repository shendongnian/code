    foreach (CGXML.ParcelRow pr in fisier.Parcel)
                    {
                        cat = pr.USECATEGORY;
                        measarea = pr.MEASUREDAREA.ToString();
                        foreach (CGXML.PersonRow pp in fisier.Person)
                        {
                            persoana = string.Concat(pp.LASTNAME, " ", pp.FIRSTNAME);
                            sout.WriteLine(string.Concat(new string[] { "\"", cadgenno.ToString(), "\",\"", sector, "\",\"", persoana, "\",\"", parcellegalarea.ToString(), "\",\"", measarea.ToString(), "\",\"", cat, "\"" }));
                        }
                    }
