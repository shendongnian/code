     private void guocheng1_Click(object sender, EventArgs e)
        {
            MyCommands myMyCommands = new MyCommands();
    
            myMyCommands.Myds() ; //this, its not a static method. Also, this is how you call a method. 
         }
    public void Myds() // This method can have any name
    {
        // Put your command code here
        Document doc = Application.DocumentManager.MdiActiveDocument;
        Database db = doc.Database;
        Editor ed = doc.Editor;
        ed.WriteMessage("\r\nThis   is  an  Initialization  Startup text.");
    }
