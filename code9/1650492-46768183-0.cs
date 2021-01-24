    string url=TextBoxSearch.Text;
    url=url.Replace("%20", "-");
    Console.WriteLine(url);
    var encode = System.Web.HttpUtility.UrlEncode(url);
    Console.WriteLine(encode);
