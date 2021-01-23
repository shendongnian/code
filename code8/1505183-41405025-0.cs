            var parameters = new
                             {
                                 api_key = "my api key",
                                 preset_id = "my preset id"
                             };
            var json = new
                       {
                           jsonrpc = "2.0",
                           id = "12345",
                           method = "my method",
                           @params = parameters
                       };
            string sResult = (new System.Web.Script.Serialization.JavaScriptSerializer()).Serialize(json);
