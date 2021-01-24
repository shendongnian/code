    #region Model For Deserialize String to Object
        public class Links
        {
        }
        public class List
        {
            public List<string> staff { get; set; }
            public List<string> clients { get; set; }
        }
        public class RootObject
        {
            public Links _links { get; set; }
            public int count { get; set; }
            public List list { get; set; }
        }
        #endregion
    
        #region Restfull Respone (String) Convert To RootObject
        public class ConvertStringToObj
        {
            public void Execute()
            {
                //Your webReq and Response progress here
                string jsonResponse="";
                var rootObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse, typeof(RootObject));
                foreach(var eachItem in rootObj.list.staff)
                {
                    var stafName = eachItem;
                }
    
            }
        }
        #endregion
