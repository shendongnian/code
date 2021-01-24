                JObject json = new JObject();
                JsonSerializerSettings testWantSvenWeetHetNietMeer = new JsonSerializerSettings();
                testWantSvenWeetHetNietMeer.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                json.Add("taak", JsonConvert.SerializeObject(ttodo, testWantSvenWeetHetNietMeer));
    
     var test = json.ToString();
                test = test.Replace("\"[", "[");
                test = test.Replace("]\"", "]");
                test = test.Replace("\\n", "");
                test = test.Replace("\\", "");
                test = test.Replace("\"{", "{");
                test = test.Replace("}\"", "}");
    
                Debug.WriteLine(test);
                var content = new StringContent(test, Encoding.UTF8, "application/json");
    
    
                var resp = client.PostAsync("InsertTaken", content);
    
    
                if (resp.Result.IsSuccessStatusCode)
                {
    
                    var repStr = resp.Result.Content.ReadAsStringAsync();
    
    
                    JObject jo = JObject.Parse(repStr.Result.ToString());
                    
                    var test2 = jo.SelectToken("InsertTakenResult", false).ToObject<string>();
                    BackgroundTaak();
                    return test2;
    
    
    
    
                }
    
                return "";
