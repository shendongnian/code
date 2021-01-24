    public class PatientModel
    {
        public List<InboxPatientModel> Patients { get; set; }
        public List<InboxDoctorModel> Doctors { get; set; }
    }
    [ResponseType(typeof(PatientModel))]
    [Route("~/api/Messages/search")]
    public IHttpActionResult GetSearch(string serchTerm = "", string messageFor = "p")
    {
        try
        {
            var patientModel = new PatientModel();
            if (messageFor == "p")
            {
                var inboxMessages = MessageToPatientList.Get(serchTerm);
                patientModel.Patients = inboxMessages;
            }
            else
            {
                var outboxMessages = MessageToDoctorList.Get(serchTerm);
                patientModel.Doctors = inboxMessages;
            }
            return Ok(patientModel);
        }
        catch (Exception ex)
        {
            //some code for exception handling....
        }
    }
