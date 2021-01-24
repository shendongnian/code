        public string RetrieveResponseData(HttpWebResponse response){
           var result;
           using StreamReader reader = new StreamReader(response.GetResponseStream()){
              result = reader.ReadToEnd();
           }
           return result;
        }
