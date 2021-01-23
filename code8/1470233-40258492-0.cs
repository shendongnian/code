            string address = "www.google.com/";
            string url = address + "?station_ids=1322&observation_source=3&starttime=[date]";
            var queryStrings = HttpUtility.ParseQueryString(url);
            queryStrings.Set("observation_source", "[ObsValue]");
            Dictionary<string, string> queryStringsList = new Dictionary<string, string>();
            foreach (var key in queryStrings.AllKeys)
            {
                queryStringsList.Add(key, queryStrings[key]);
            }
            var newAddress = string.Empty;
            foreach (var item in queryStringsList)
            {
                newAddress = newAddress + item.Key + "=" + item.Value + "&";
            }
            Console.Write(newAddress);
