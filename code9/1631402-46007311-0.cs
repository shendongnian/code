    using System;
    using LiteDB;
    
    namespace FixProductsProperty
    {
    
        public enum ListAction
        {
            Add = 0,
            Remove,
            Update,
            Disable,
            Enable
        }
    
        class DbInteractions
        {
            public static readonly string dbFilename = "MyDatabaseName.db";
            public static readonly string dbItemsTableName = "MyTableName";
            public void ToDataBase(ListAction incomingAction, TrackingDbEntry dbEntry = null)
            {
    
                if (dbEntry == null)
                {
                    Exception ex = new Exception("dbEntry can not be null");
                    throw ex;
                }
    
    
                // Open database (or create if not exits)
                using (var db = new LiteDatabase(dbFilename))
                {
    
                    var backupListInDB = db.GetCollection<TrackingDbEntry>(dbItemsTableName);
    
                    //ovverride action if needed
                    if (incomingAction == ListAction.Add)
                    {
                        var tempone = backupListInDB.FindOne(p => p.ProductID == dbEntry.ProductID);
                        if (backupListInDB.FindOne(p => p.ProductID == dbEntry.ProductID) != null)
                        {
                            //the record already exists
                            incomingAction = ListAction.Update;
                            //IOException ex = new IOException("Err: Duplicate. " + dbEntry.ProductID + " is already in the database.");
                            //throw ex;
                        }
                        else
                        {
                            //the record does not already exist
                            incomingAction = ListAction.Add;
                        }
                    }
    
                    switch (incomingAction)
                    {
                        case ListAction.Add:
                            backupListInDB.Insert(dbEntry);
                            break;
                        case ListAction.Remove:
                            //backupListInDB.Delete(p => p.FileOrFolderPath == backupItem.FileOrFolderPath);
                            if (dbEntry.ProductID != 0)
                            {
                                backupListInDB.Delete(dbEntry.ProductID);
                            }
                            break;
                        case ListAction.Update:
                            if (dbEntry.ProductID != 0)
                            {
                                backupListInDB.Update(dbEntry.ProductID, dbEntry);
                            }
                            break;
                        case ListAction.Disable:
                            break;
                        case ListAction.Enable:
                            break;
                        default:
                            break;
                    }
    
                    backupListInDB.EnsureIndex(p => p.ProductID);
                    // Use Linq to query documents
                    //var results = backupListInDB.Find(x => x.Name.StartsWith("Jo"));
                }
            }
    
        }
    }
