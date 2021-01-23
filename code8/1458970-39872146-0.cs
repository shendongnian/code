    [HttpGet]
    [Route("api/MdmwPatientController/GetPatSummary/{PatId}")]
    public HttpResponseMessage GetPatSummary(string PatId)
    {
        PatientSummary Pat = new PatientSummary();
    
        HttpResponseMessage Response = new HttpResponseMessage();
        string yourJson = Pat.GetPatient(PatId);
        Response = this.Request.CreateResponse(HttpStatusCode.OK, yourJson);
        return Response;
    }
