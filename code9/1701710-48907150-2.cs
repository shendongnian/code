         OverallAverage = clinic.Doctors
              .Select(doctor => doctor.AverageCost)
              .Average(),
         Clinic = clinic,
    })
    .OrderBy(clinic => clinic.OverallAverage)
    .Select(clinic => clinic);
