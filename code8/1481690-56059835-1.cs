      public T1 FetchObjectUploadAPI(string strAPIMethod, NameValueCollection collection, FileUpload file, ControllerType enObj)
        {
            T1 objReturn;
            try
            {
                string url = strWebAPIUrl + getControllerName(enObj) + strAPIMethod;
                MultipartFormDataContent content = new MultipartFormDataContent();
               
             
                int count = collection.Count;
                List<string> Keys = new List<string>();
                List<string> Values = new List<string>();
         
                //MemoryStream filedata = new MemoryStream(file);
                //Stream  stream = filedata;
                for (int i = 0; i < count; i++)
                {
                    Keys.Add(collection.AllKeys[i]);
                    Values.Add(collection.Get(i));
                  
                }
                for (int i = 0; i < count; i++)
                {
                    content.Add(new StringContent(Values[i], Encoding.UTF8, "multipart/form-data"), Keys[i]);
                }
                int fileCount = file.PostedFiles.Count();
                HttpContent filecontent = new StreamContent(file.PostedFile.InputStream);
               
               
                content.Add(filecontent, "files");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    objReturn = (new JavaScriptSerializer()).Deserialize<T1>(response.Content.ReadAsStringAsync().Result);
                }
                else
                    objReturn = default(T1);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("FetchObjectAPI", ex, log4net_vayam.Constants.levels.ERROR);
                throw (ex);
            }
            return objReturn;
        }
