    var source = new HtmlWebViewSource();
            string url = DependencyService.Get<IBaseUrl>().GetBaseUrl();
            string TempUrl = Path.Combine(url, "terms.html");
            source.BaseUrl = url;
            string html;
            try
            {
                using (var sr = new StreamReader(TempUrl))
                {
                    html = sr.ReadToEnd();
                    source.Html = html;
                }
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
   
