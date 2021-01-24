    [HttpPost]
    public ActionResult AddSampleDataJSON(HttpPostedFileBase uploadedFile)
    {
        using (StreamReader r = new StreamReader(uploadedFile.InputStream))
        {
            string json = r.ReadToEnd();
            List<Event> events = JsonConvert.DeserializeObject<List<Event>>(json);
        }
        return View();
    }
