    [ResponseType(typeof(List<InboxPatientModel>))]
    [Route("~/api/Messages/searchpatients")]
    public IHttpActionResult GetPatients(string searchTerm = "")
    {
    }
    [ResponseType(typeof(List<InboxDoctorModel>))]
    [Route("~/api/Messages/searchdoctors")]
    public IHttpActionResult GetDoctors(string searchTerm = "")
    {
    }
