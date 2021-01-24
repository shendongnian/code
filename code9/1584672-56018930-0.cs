       foreach (var vSelectedDok in doks)
                        {
                            //disable detection of changes to improve performance
                            vDal.Configuration.AutoDetectChangesEnabled = false;
                            
                            vDal.Dokumente.Attach(vSelectedDok);
        
                            vDal.Entry(vSelectedDok).Property(x=>x.Status).IsModified=true;
                            vDal.Entry(vSelectedDok).Property(x => x.LastDateChanged).IsModified = true;
        }
        vDal.SaveChanges();
