    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.IO;
    using Newtonsoft.Json;
    
    namespace SetGetMultipleCookies
    {
        public partial class GetSetCookiesForm : Form
        {
            string readCookiesUrl = "http://test.dev/_test/cookies/readcookie.php";
            string setCookiesUrl = "http://test.dev/_test/cookies/setcookie.php";
            CookieContainer cookie_container = new CookieContainer();
            CookieCollection cookie_collection = new CookieCollection();
    
    
            public GetSetCookiesForm()
            {
                InitializeComponent();
            }
    
    
            private void getCookiesButton_Click(object sender, EventArgs e)
            {
                // begins variable for page content.
                string pageSource;
                // send url request to web page.
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.readCookiesUrl);
                request.CookieContainer = this.cookie_container;
                request.UserAgent = "My C# App";
    
                // get response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // reset cookie collection.
                this.cookie_collection = new CookieCollection();
                // loop through cookie container to set only non-expired to cookie collection.
                var cookies_container = this.cookie_container.GetCookies(new Uri(this.readCookiesUrl));
                foreach (Cookie each_cookie in cookies_container)
                {
                    if (!each_cookie.Expired)
                    {
                        this.cookie_collection.Add(each_cookie);
                    }
    
                }
    
                // read the page content
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    pageSource = sr.ReadToEnd();
                }
    
                // display debug.
                resultBox.Text = pageSource.Replace("\n", "\r\n") + "\r\n";
                resultBox.Text += "\r\nCookies (" + this.cookie_collection.Count + ") ==========\r\n";
                foreach (Cookie each_cookie in this.cookie_collection)
                {
                    resultBox.Text += each_cookie.ToString() + "; expires=" + each_cookie.Expires + "; path=" + each_cookie.Path + ";domain=" + each_cookie.Domain + "\r\n";
                    if (each_cookie.Expired)
                    {
                        resultBox.Text += "cookie expired.\r\n";
                    }
                }
    
                // clear memory.
                pageSource = default(String);
                request = default(HttpWebRequest);
                response = default(HttpWebResponse);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
    
    
            private void setCookiesButton_Click(object sender, EventArgs e)
            {
                // send url request to set cookie.
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.setCookiesUrl);
                request.Method = "GET";
                request.CookieContainer = this.cookie_container;
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "My C# App";
                // get response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // set cookies collection
                this.cookie_collection = response.Cookies;
    
                // debug
                resultBox.Text = "Headers ==========\r\n";
                foreach (string each_header in response.Headers)
                {
                    resultBox.Text += each_header + " = " + response.Headers[each_header].Replace("\n", "\r\n").Replace("\r", "\r\n") + "\r\n";
                }
                resultBox.Text += "\r\nCookies (" + this.cookie_collection.Count + ") ==========\r\n";
                foreach (Cookie each_cookie in this.cookie_collection)
                {
                    resultBox.Text += each_cookie.ToString() + "\r\n";
                    resultBox.Text += each_cookie.Name + "\r\n";
                    resultBox.Text += each_cookie.Value + "\r\n";
                    resultBox.Text += each_cookie.Expires + "\r\n";
                    resultBox.Text += each_cookie.Path + "\r\n";
                    resultBox.Text += each_cookie.Domain + "\r\n";
                    resultBox.Text += each_cookie.Secure + "\r\n";
                    resultBox.Text += each_cookie.HttpOnly + "\r\n";
                    resultBox.Text += each_cookie.Expired + "\r\n";
                    resultBox.Text += "\r\n";
                    // add cookie to cookiecontainer
                    this.cookie_container.Add(each_cookie);
                }
                // get response body.
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String responseText = reader.ReadToEnd();
                    // json decode
                    //LoginResponse responsej = JsonConvert.DeserializeObject<LoginResponse>(responseText);// too lazy to do this.
                    // display debug.
                    resultBox.Text += "Response body ==========\r\n";
                    resultBox.Text += responseText + "\r\n";
                    // clear memory.
                    reader = default(StreamReader);
                    responseText = default(String);
                }
    
                // clear memory.
                request = default(HttpWebRequest);
                response = default(HttpWebResponse);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
    
    
            private void removeCookiesButton_Click(object sender, EventArgs e)
            {
                this.cookie_container = new CookieContainer();
                this.cookie_collection = new CookieCollection();
    
                resultBox.Text = "Logged out.";
    
                // clear memory.
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
