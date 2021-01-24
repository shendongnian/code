    public class PatientHelpers
    {
        public void SavePatient(Patient unencryptedPatient)
        {
            var encrypted = Crypto.EncryptPatient(unencryptedPatient);
            PatientDb.SavePatient(encrypted);
        }
    }
    public static class Crypto
    {
        public Patient EncryptPatient(Patient patient)
        {
            //whatever happens here, you didn't post this
            return patient;
        }
    }
