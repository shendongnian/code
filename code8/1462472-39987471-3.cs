    public Save(Ticket header, TicketLines newLines) {
                Debug.WriteLine("init save");
                 dbConnection.RunInTransactionAsync(new Action<SQLite.Net.SQLiteConnection>(tran =>
                {
                     dbConnection.Insert(header).ContinueWith((t) =>
                    {
                        Debug.WriteLine("-> New header ID: {0}", header.Id);                       
                        foreach (var item in newLines)
                        {
                            item.DocumentId = = header.Id;
                        }
                         dbConnection.InsertAll(newLines);                     
                    });
                    //tran.Commit();                    
                }));
                Debug.WriteLine("End Save");
}
