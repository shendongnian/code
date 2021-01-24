    url = "https://api.sandbox.ebay.com/sell/inventory/v1/bulk_update_price_quantity";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            //request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("Authorization", "Bearer **OAUTH TOKEN GOES HERE WITHOUT ASTERIKS**");
            // Send the request
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonInventoryRequest);
                streamWriter.Flush();
                streamWriter.Close();
            }
            // Get the response
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            if (response != null)
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    // Parse the JSON response
                    var result = streamReader.ReadToEnd();
                }
            }
