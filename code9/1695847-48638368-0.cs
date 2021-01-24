    class Test
    {
       public string SessionID { get; set; }
    }
    
    //after getting response from server
    Test tmp = JsonConvert.DeserializeObject<Test>(responseFromServer);
    Label1.Text = tmp.SessionID; 
