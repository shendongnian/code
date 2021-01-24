        var query = from Record in SqlInfo.SqlTable.T_SALs 
                    where Record.EtatPaie == 3 
                    select new SomeType { 
                        Matricule = Record.MatriculeSalarie, 
                        Nom = Record.Nom, 
                        Prenom = Record.Prenom, 
                        Email = Record.EMail 
                    };
    
        public void SetListOfSalariesToEmailTo(IQueryable<SomeType> query)
        {
            ListOfSalary = query;
        }
