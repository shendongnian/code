    var indexes = new List<AbstractIndexCreationTask>();
    indexes.Add(new MyIndex1());
    indexes.Add(new MyIndex2());
    indexes.Add(new MyIndex....());
    var transfos = new List<AbstractTransformerCreationTask>();
    transfos.Add(new MyTransformer1());
    transfos.Add(new MyTransformer2());
    transfos.Add(new MyTransformer...());
    // put indexes in 1 command
    var indexesToPut = IndexCreation.CreateIndexesToAdd(indexes, documentStore.Conventions);
    documentStore.DatabaseCommands.PutIndexes(indexesToPut);
    // don't forget transformers
    foreach (var item in transfos)
    {
        item.Execute(Store);
    }
