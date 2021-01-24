    WebClient client = new WebClient();
    
    //Get request
    //                                                                              | GET DATA                   |
    string response = client.DownloadString("http://firebolt.netcom.no:8080/sms/send?number=4793224070&message=hei");
    //Post request
    NameValueCollection nvc = new NameValueCollection(); //Stores post data
    nvc.Add("number", "4793224070"); //value 1
    nvc.Add("message", "hei"); //value 2
    byte [] tmp = client.UploadValues("http://url.com/", nvc); //request
    response = Encoding.UTF8.GetString(tmp);
