            string requestURL = baseRequestURL + "api/authentication/sign-in";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestURL);
                var credentials = String.Format("{0}:{1}", qcSettings.Username, qcSettings.Password);
                request.CookieContainer = authenticationCookieContainer;
                request.Headers.Set(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));
                var authResponse = request.GetResponse();
                errorString = String.Empty;
            }
            catch (System.Net.WebException except)
            {
                errorString = except.Message;
                return false;
            }
            errorString = String.Empty;
            return true;
        }
