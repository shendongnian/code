    [HttpPut]
    public HttpResponseMessage PutSIMSData(string langid, byte period, byte year, string data, int userId)
    {
        if (ModelState.IsValid)
        {
            try
            {
                SIMSData simsdata = db.SIMSDataDbSet.Find(langid, period, year);
                if(simsdata == null) {
                   // entity not found
                }
                // Updating values
                simsdata.UserID = userId;
                simsdata.Data = data;
                db.Entry(simsdata).State = EntityState.Modified;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, simsdata);
            } 
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
    
        else
        {
             return Request.CreateResponse(HttpStatusCode.BadRequest, simsdata);
        }
    }
