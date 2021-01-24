    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/api/Test/TestPostData");
    request.Method = "POST";
    SampleModel model = new SampleModel();
    model.PostData = "Test";
    request.ContentType = "application/json";
    
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    using (var sw = new StreamWriter(request.GetRequestStream()))
          {
                     string json = serializer.Serialize(model);
                     sw.Write(json);
                     sw.Flush();
          }
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
