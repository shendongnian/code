            // write the form values into the request message
            using (var stream = webRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            // get the contents of the response (after logon page is redirected)
            responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            responseData = responseReader.ReadToEnd();
            responseReader.Close();
