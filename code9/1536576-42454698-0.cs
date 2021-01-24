        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {    
             string json= streamReader.ReadToEnd();
             //List<DeSerialiseBL> myDeserializedObjList = (List<DeSerialiseBL>)Newtonsoft.Json.JsonConvert.DeserializeObject(Request[json], typeof(List<DeSerialiseBL>));
             List<DeSerialiseBL> myDeserializedObjList = (List<DeSerialiseBL>)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(List<DeSerialiseBL>));
        }
