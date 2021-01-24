     try
            {
                dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(response.Content, new Newtonsoft.Json.JsonSerializerSettings() { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                return x;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
