    public async Task GetTestData()
    {
        try
        {                
            ARestService rest = new ARestService();
            await rest.MyTest();
            var tst = "Done?";
        }
        catch(Exception ex)
        {
            string a = ex.Message;
        }
    }
