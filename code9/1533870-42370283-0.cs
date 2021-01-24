    var fileResult = remittanceCenterSummaryListModel.RemittanceBatchSummaryRecord
                .GroupBy(x => new { x.FileId, x.BatchType })
                .Select(x => 
                { 
                    var firstObj = x.FirstOrDefault();
                    return new RemitanceCenterFileSummarizedModel()
                    { 
                       FileId = x.Key.FileId,
                       SourceFileName = firstObj.SourceFileName,
                       BatchCode = firstObj.BatchCode,
                       BatchType  = x.Key.BatchType,
                       BatchTotal  = x.Sum(z => z.PaymentAmt),
                       RecordCount = x.Count()
                    };
                });
