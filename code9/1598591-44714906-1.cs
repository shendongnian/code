    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            Class1.PostDevices x = new Class1.PostDevices();
    
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webAddr);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Timeout = 5000;
    
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string jsonstring;
                MemoryStream stream1 = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Class1.PostDevices));
    
                x.notification = new Class1.Notification();
                x.profile = "dev";
                x.notification.message = "Hello World";
    
                ser.WriteObject(stream1, x);
                stream1.Position = 0;
                StreamReader sr = new StreamReader(stream1);
    
                jsonstring = sr.ReadToEnd();
                Debug.WriteLine(JObject.Parse(jsonstring));
    
                streamWriter.Write(jsonstring);
                streamWriter.Flush();
            }
            HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Debug.WriteLine(JObject.Parse(result));
                    Reponse.PostDevicesReponse MyResult = JsonConvert.DeserializeObject<Reponse.PostDevicesReponse>(result);
                }
            }
        }
      } 
      catch (Exception e)
      {
         ExceptionLogging.SendErrorToText(e);                
      }
    }
