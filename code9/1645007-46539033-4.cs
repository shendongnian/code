    public static async Task<Feeds> getJson()
        {
            using (var response = await _client.GetAsync("https://thingspeak.com/channels/301726/field/1.json"))
            {
                if (response.IsSuccessStatusCode)  {
                    var json = await response.Content.ReadAsStringAsync();
                    JObject obj = JObject.Parse(json);
                    Feeds feed = null;
                    foreach (var feedObj in obj["feeds"])
                    {
                        feed = JsonConvert.DeserializeObject<Feeds>(feedObj.ToString());
                        double feild1 = feed.field1;
                    }
                    return feed;
                }
            }
            return null;
        }
