    [ServiceContract]
    public interface IService1
    {
         //Get a patient's data
        [OperationContract]
        [ServiceKnownType(typeof(Fallible<Patient>))]
        [ServiceKnownType(typeof(Success<Patient>))]
        Fallible<Patient> GetPatient(int id);
    
         //Get a list of Patients
        [OperationContract]
        List<Patient> GetPatients();
    
        //Get a list of patients
        [OperationContract]
        [ServiceKnownType(typeof(Fallible<List<Patient>>))]
        [ServiceKnownType(typeof(Success<List<Patient>>))]
        Fallible<List<Patient>> GetSpecificPatients(string type);
    }
