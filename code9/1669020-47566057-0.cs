    public IHttpActionResult GetAllCustomers()
    {
        // code....
        string json = JsonConvert.SerializeObject(lstPersons);
        return Json(json);
    }
