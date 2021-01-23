    var selectedPatientsWithSelectedMeds = patientMedsList.Where(p => p.IsSelected)
    													  .Select(p => new PatientMeds
    													  {
    														Patient = p.Patient,
    														Meds = p.Meds.Where(m => m.IsSelected).ToList()
    													  })
    													  .ToList();
