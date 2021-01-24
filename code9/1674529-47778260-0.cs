    public async Task<ActionResult> Index(Transmission t)
        {
            ViewBag.ErrorMessage = "";
            ViewBag.OtherMessage = "";
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(Transmission));
                using (StringWriter sw = new StringWriter())
                {
                    xmlSerializer.Serialize(sw, t);
                    var contentData = sw.ToString();
                    var httpContent = new StringContent(contentData, Encoding.UTF8, "application/xml");
                    var httpClient = new HttpClient();
                    httpClient.Timeout = new TimeSpan(0, 1, 0);
                    var response = await httpClient.PostAsync("", httpContent);
                    ViewBag.OtherMessage = await response.Content.ReadAsStringAsync();
                    return View("Error"); //TODO: change this to success when I get the 500 error fixed
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
