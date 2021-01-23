    void LoadReturn()
    {
        string name = Request.QueryString["name"];
        string city = Request.QueryString["city"];
        string returnValue="Hello Mr."+ name + " who lives in " + city;
    
        Response.Write(returnValue);
        Response.End();
    }
