    var transact = db.Transactions
                            .Where(x => x.CustomerID == cusId)
                            .Where(s => s.ReturnStatus == "FALSE")
                            .Join(db.Videos,
                            v => v.VideoID,
                            t => t.VideoID,
                            (transaction, videos) => new { 
                            TransactionID = transaction.TransactionID,
                            VideoTitle = videos.VideoTitle }).ToList();
