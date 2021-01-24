    [HttpPost]
        public ActionResult YourAction(string data)
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();
            try
            {
                var request = JsonConvert.DeserializeObject<YourClassNameHere>(json);
            }
            catch (Exception ex)
            {
            }
            
            return Json(JsonConvert.SerializeObject(response));
        }
