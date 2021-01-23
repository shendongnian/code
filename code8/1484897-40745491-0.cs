    foreach (var personAgreementRelation in personAgreementRelations)
    {
    	Context.PersonAgreementRelations.Add(personAgreementRelation);
    }
    
    Context.Configuration.ValidateOnSaveEnabled = false;
    Context.Configuration.AutoDetectChangesEnabled = false;
