    {
                    await dbConnection.InsertAsync(header).ContinueWith((t) =>
                    {
                        Debug.WriteLine("-> New header ID: {0}", header.Id);                       
                        foreach (var item in newLines)
                        {
                            item.DocumentId = = header.Id;
                        }
                        await dbConnection.InsertAllAsync(newLines);                     
                    });
                    //tran.Commit();                    
                }));
