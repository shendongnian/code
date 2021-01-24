    public Patient CreatePatient(Patient patient)
    {
        string errorMessage = String.Empty;
        Patient patientReturned = null;
        County county = null;
    
        try
        {
                using (AppContext ctx = new AppContext())
               {
                   // ONLY Pre-existing counties are permitted
                    county = ctx.Counties.Where(c => c.CountyName == patient.CountyName).SingleOrDefault<County>();
                    ctx.Patients.Add(patient);
                    ctx.SaveChanges();
                    patientReturned = patient;
               }
        } // end try
        catch (Exception err)
        {
            errorMessage = err.Message;
        } // end catch (Exception err)
    
        return patientReturned;
    } // end public Patient CreatePatient(Patient patient)
