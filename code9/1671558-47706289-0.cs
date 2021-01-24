    Db.Admissions
        .Select(a => new 
        { 
            CurrentClinic = CurrentFacility(a),
            Admission = a
        })
        .Where(a => 
            (a.CurrentClinic != null && !a.CurrentClinic.Company.IsHomeCompany && a.Admission.ReferralClinicId == clinicid) ||
            (a.CurrentClinic.Company.IsHomeCompany && a.CurrentClinic.ClinicId == clinicid));
