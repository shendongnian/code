                using (var _context = new DB.Entities())
                {
                    var IDClients = _context.Database.SqlQuery<int>("select distinct idclient FROM dbo.ReportClient LEFT OUTER JOIN dbo.ReportClientDocument ON dbo.ReportClient.IDClient = dbo.ReportClientDocument.IDClient");
                    foreach (var IDClient in IDClients)
                    {
                        // process the row here
                    }
                }
