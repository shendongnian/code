    if (_patent.PatentId == 0)
    {
        _patient.PatientID = txtPatientId.Text; // If you're using an identity column, remove this line. I would also strongly suggest not letting the user change this...
        SourceDal.SourceEntities.Patients.Add(_patient);
    }
