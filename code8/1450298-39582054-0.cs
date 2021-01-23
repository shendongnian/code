    var batchDict = batches.ToDictionary(b => b.BatchId);
    var documents = _context.DocTable.Where(doc => batchDict.Keys.Contains(doc.BatchId));
    BatchViewModels.AddRange(documents.Select(d => new Batch
    {
        BatchId = d.BatchId,
        Time = batchDict[d.BatchId].BatchEnd.TimeOfDay, // you only want the time?
        HardCopyDestination = d.HardCopyDestination
    });
