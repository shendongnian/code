    using System;
    
    // Use ACE DAO to Compact an Access .ACCDB file
    // This method uses late binding to create the ACE DAO.DBEngine object
    public bool CompactDatabaseACE(string SourceDb, string TempPath)
    {
        string Temp1Db, Temp2Db;
        object[] oParams;
        bool retVal = false;
        Temp1Db = Path.Combine(TempPath, Path.GetFileNameWithoutExtension(SourceDb) + ".cmp");
        Temp2Db = Path.Combine(Path.GetDirectoryName(SourceDb),Path.GetFileNameWithoutExtension(SourceDb) + ".old");
        if (File.Exists(Temp1Db))
            File.Delete(Temp1Db);
        if (File.Exists(Temp2Db))
            File.Delete(Temp2Db);
        oParams = new object[]
        {
            SourceDb, Temp1Db
        };
        try
        {
            object DBE = Activator.CreateInstance(Type.GetTypeFromProgID("DAO.DBEngine.120"));
            DBE.GetType().InvokeMember("CompactDatabase", System.Reflection.BindingFlags.InvokeMethod, null, DBE, oParams);
            if (File.Exists(Temp1Db))
            {
                try
                {
                    File.Move(SourceDb, Temp2Db);
                }
                catch { }
                if (File.Exists(Temp2Db))
                {
                    try
                    {
                        File.Move(Temp1Db, SourceDb);
                    }
                    catch { }
                    if (File.Exists(SourceDb))
                    {
                        retVal = true;
                    }
                }
                if (File.Exists(Temp1Db))
                    File.Delete(Temp1Db);
                if (File.Exists(Temp2Db))
                    File.Delete(Temp2Db);
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(DBE);
            DBE = null;
        }
        catch (Exception ex)
        {
            // Do something with the error
        }
        return retVal;
    }
