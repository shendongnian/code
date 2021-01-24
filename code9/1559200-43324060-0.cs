    String dbFolder = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/project_name/";
    String dbFileName = "project_name.db";
    String dbPath = dbFolder + dbFileName;
    //To check if the database file exists: System.IO.File.Exists(dbPath);
    //To delete the database file: System.IO.File.Delete(dbPath);
    SQLiteConnection dbConn = new SQLiteConnection(dbPath);
