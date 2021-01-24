     public class ResponseData
        {
            public string status { get; set; }
            public string message { get; set; }
        }
        public ResponseData CheckIFSCCodeValid(string IFSCcode)
        {
            WebClient client1 = new WebClient();
            string jsonString = client1.DownloadString("http://api.techm.co.in/api/v1/ifsc/"+ IFSCcode);
            ResponseData responseData = new ResponseData();
            responseData = JsonConvert.DeserializeObject<ResponseData>(jsonString);
            return responseData;
        }
