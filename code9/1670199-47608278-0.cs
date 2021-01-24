            try
            {
                rawResponse = Encoding.ASCII.GetString(client.UploadData(Url, "POST", Encoding.Default.GetBytes(jsonString)));
                var responseHeaders = client.ResponseHeaders;
            }
            catch (WebException wex) // To handle error
            {
                // wex.Response.Headers // You can retrieve the headers
                //((HttpWebResponse)wex.Response).StatusCode //You can handle StatusCode like this;
            }
