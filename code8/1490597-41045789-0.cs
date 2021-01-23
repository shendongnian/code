    - For the C# program, it need to add the “U2.Data.Client” reference to the project first.
    
    - Create new U2 Toolkit Object .
    
            using U2.Data.Client;
            using U2.Data.Client.UO;
            U2Connection u2connect = new U2Connection();
            UniSession u2session;
            UniCommand u2cmd;
            
        - Set the Object properties and connection.
                      Connection_string="server=localhost;Database=XDEMO;UserID=user;Password=pass;Pooling=False;AccessMode=Native;ServerType=UniVerse;RpcServviceType=uvcs";
            
            u2connect.ConnectionString = Connection_string;
            u2connect.Open();
            u2session = u2connect.UniSession;
            
        - Test UniObjects Command Object
            u2cmd = u2session.CreateUniCommand();
            u2cmd.Command = "LIST VOC";
            u2cmd.Execute();
            // Show result:
            MessageBox.Show(u2cmd.Response.ToString(); 
                    
        - Close the session
            u2connect.Close();
