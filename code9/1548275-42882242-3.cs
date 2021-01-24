    private InputField employerIdinputField;
    
    void Start()
    {
        employerIdinputField = GameObject.Find("txtEmployeeID").GetComponent<InputField>();
    }
    public void InsertScore()
    {
    
       connectionString = "URI=file:" + Application.dataPath + "/HighScoreDB.sqlite";
    
        using (SqliteConnection con = new SqliteConnection(connectionString))
        {
    
        SqliteCommand cmd = new SqliteCommand();
        cmd.CommandText = @"INSERT INTO HighScores(EmployeeID, EmployeeFirstname,    TestScore, ROLE) VALUES (@EmployeeID,@EmployeeFirstName,@TestScore,@Role)";
        cmd.Connection = con;
    
        //FIXED LINE!
        cmd.Parameters.Add(new  SqliteParameter("@EmployeeID",employerIdinputField.text));
        cmd.Parameters.Add(new SqliteParameter("@EmployeeFirstName", "Anand3"));
        cmd.Parameters.Add(new SqliteParameter("@TestScore", "65"));
        cmd.Parameters.Add(new SqliteParameter("@Role", "Tester"));
        con.Open();
        cmd.ExecuteNonQuery();
        }
    }
