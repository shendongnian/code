	patientsMeds
		.PatientMedsList
		.Where(m => m.Patient.IsSelected)
        .ToList()
		.ForEach(m => m.Meds.RemoveAll(med => !med.IsSelected));
