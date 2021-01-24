    string uriString = "http://www.Testcom";
                                        
    WebClient myWebClient = new WebClient();
    string postData = "=data";
    myWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
    Console.WriteLine(myWebClient.Headers.ToString());
    byte[] byteArray = Encoding.ASCII.GetBytes(postData);
    byte[] responseArray = myWebClient.UploadData(new Uri(uriString), "POST", byteArray);
