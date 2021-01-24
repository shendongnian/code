     var fileResult = remittanceCenterSummaryListModel.RemittanceBatchSummaryRecord
                         .GroupBy(x => new 
                                      { 
                                        x.FileId,
                                        x.SourceFileName,
                                        x.BatchType,
                                        x.BatchCode 
                                      })
                         .Select(x => new
                                     {
                                       FileId = x.Key.FileId,
                                       SourceFileName = x.Key.SourceFileName,
                                       BatchType = x.Key.BatchType,
                                       BatchCode = x.Key.BatchCode,
                                       BatchTotal= x.Sum(y=>y.PaymentAmt),
                                       RecordCount = x.Count()
                                 });
