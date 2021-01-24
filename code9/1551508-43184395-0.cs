      private SQLiteConnection conn;      
      protected override void OnCreate(Bundle bundle)
      {
       base.OnCreate(bundle);
       Forms.Init(this, bundle);
    
       var sqliteFilename = "ToDoItemDB.db3";
       string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
       var path = Path.Combine(libraryPath, sqliteFilename);
       conn = new SQLiteConnection(path);
       //create table
       conn.CreateTable<Todo>();
    
       LoadApplication(new App());
      }
  
