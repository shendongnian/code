    // Get the response from the server
    using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
    {
        // Pass the response into a stream reader
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            // Grab the JSON response as a string
            string rawJson = reader.ReadToEnd();
            // Parse the string into a JObject
            var json = JObject.Parse(rawJson);
            // Get the JToken representing the ASP.NET "d" parameter
            var d = json.GetValue("d");
            // Parse the string value of the object into a jArray
            var jArray = JArray.Parse(d.ToString());
            // At this point you can start looking for the items.
        }
    }
