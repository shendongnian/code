    // Drag & Drop the gameobject with the InputField component
    public InputField username;
    
    // Drag & Drop the gameobject with the InputField component
    public InputField password;
    
    // Drag & Drop the gameobject with the Button component
    public Button register;
    
    SqliteConnection dbconn;
    
    // Use this for initialization
    void Start ()
    {
        OpenDatabaseConnection();
        register.onClick.AddListener (OnRegisterButtonClicked);
    }
    void OnDestroy ()
    {
        CloseDatabaseConnection();
    }
    
    private void OnRegisterButtonClicked()
    {
        // Make sure the username and password are not empty
        if( !string.IsNullOrEmpty( username.text ) && !string.IsNullOrEmpty( password.text ) )
        {
            InsertUser( username.text, password.text );
        }
        else
        {
            Debug.LogError("Username or password is missing");
        }
    }
    
    private void InsertUser( string username, string password )
    {
        SqliteCommand cmd = new SqliteCommand ();
        string sqlInsert = "INSERT INTO user (username, password) VALUES ('" +username+ "' , '"+password+"')";
        cmd.CommandText = sqlInsert;
        cmd.Connection = dbconn;
        cmd.ExecuteNonQuery ();
        cmd.Dispose ();
        cmd = null;
    }
    
    private void OpenDatabaseConnection()
    {
        string conn = "URI=file:" + Application.dataPath + "/thesisdatabase.db";
        dbconn = new SqliteConnection (conn);
        dbconn.Open ();
    }
    
    private void CloseDatabaseConnection()
    {
        dbconn.Close ();
        dbconn = null; 
    }
