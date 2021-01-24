    string path = "/myfolder/subfolder/testfile.txt";
    if (ItemExist(path))
    {
        string aa = GetItemInfo(path);
        return new string[]
        {
            "Hello",
            aa,
            "World"
        };
    }
    else
    {
        var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
        responseMessage.Content = new StringContent("The file path which you requested is not found");
        throw new HttpResponseException(responseMessage);
    }
