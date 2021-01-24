    public void GetParameters(FormCollection form, HttpRequest request)
    {
        var parameters = Convert(form);
        parameters = Convert(request.Parameters);
    }
    
    public YourParameters Convert(NameValueCollection form)
    {
        //your code here
    }
