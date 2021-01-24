            string actualResponse = "{\"Items\":[{\"CustomerCode\": \"ABC008\", \"TestBla\":\"Bla\"}]}";
            JObject jsonResult = JObject.Parse(actualResponse);
            // Get Null exception. Property does not exist.
            //Object value = jsonResult.GetType().GetProperty("Items").GetValue(jsonResult, null); 
            // Will work
            var items = jsonResult["Items"];
            // To assert CustomerCode:
            string value = jsonResult["Items"][0]["CustomerCode"].Value<string>();
            Assert.AreEqual("ABC008", value);
