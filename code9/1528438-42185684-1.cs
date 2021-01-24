            string actualResponse = "{\"Items\":[{\"CustomerCode\": \"ABC008\", \"TestBla\":\"Bla\"}]}";
            JObject jsonResult = JObject.Parse(actualResponse);
            // Get Null exception. Property does not exist.
            //Object value = jsonResult.GetType().GetProperty("Items").GetValue(jsonResult, null); 
            // Will work
            var items = jsonResult["Items"];
