        [HttpPut]
        public HttpResponseMessage PutSIMSData(HttpRequestMessage req)
        {
            try
            {
                SIMSData simsdata = new SIMSData();
                string jsonContent = req.Content.ReadAsStringAsync().Result;
                simsdata = JsonConvert.DeserializeObject<SIMSData>(jsonContent);
                if (ModelState.IsValid)
                {
                    db.Entry(simsdata).State = EntityState.Modified;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, simsdata);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, simsdata);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
