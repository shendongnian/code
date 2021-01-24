    var result = Clinics.Select(clinic => new
    {
         CheapestDoctor = clinic.Doctors
              .OrderBy(doctor => doctor.AverageCost)
              .FirstOrDefault(),
         Clinic = clinic,
    })
    .OrderBy(clinic => clinic.CheapestDoctor.AverageCost)
    .Select(clinic => clinic);
