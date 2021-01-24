            // first, request the login form to get the viewstate value
            HttpWebRequest webRequest = WebRequest.Create("http://localhost:57478/LoginForm.aspx") as HttpWebRequest;
            StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();
            // extract the VIEWSTATE, VIEWSTATEGENERATOR and EVENTVALIDATION values and build out POST data 
            string viewState = ExtractViewState(responseData);
            string viewStateGenerator = ExtractViewStateGenerator(responseData);
            string eventValidation = ExtractEventValidation(responseData);
            NameValueCollection outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
            outgoingQueryString.Add("__VIEWSTATE", viewState);
            outgoingQueryString.Add("tbUserName", "testuser");
            outgoingQueryString.Add("tbPassword", "testpassword");
            outgoingQueryString.Add("cmdLogIn", "Log In");
            outgoingQueryString.Add("__VIEWSTATEGENERATOR", viewStateGenerator);
            outgoingQueryString.Add("__EVENTVALIDATION", eventValidation);
            var data = Encoding.ASCII.GetBytes(outgoingQueryString.ToString());
            CookieContainer cookies = new CookieContainer();
            // now post to the login form
            webRequest = WebRequest.Create("http://localhost:57478/LoginForm.aspx") as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookies;
            // write the form values into the request message
            using (var stream = webRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            // get the contents of the response (after logon page is redirected)
            responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            responseData = responseReader.ReadToEnd();
            responseReader.Close();
