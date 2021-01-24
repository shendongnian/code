    public List<Appointment> GetList(int id)
    {
    	List<Appointment> ret;
    	using (var db = new SqlConnection(connstring))
    	{
    		const string sql = @"SELECT AP.[Id], AP.Diagnostics, AP.Sintomns, AP.Prescription, AP.DoctorReport, AP.AddressId,
    		AD.Id, AD.Street, AD.City, AD.State, AD.Country, AD.ZIP, Ad.Complement,
    		D.Id, D.Bio, d.CRMNumber, D.CRMNumber, D.CRMState,
    		P.Id,
    		S.Id, S.Name,
    		MR.Id, MR.Alergies, MR.BloodType, MR.DtRegister, Mr.HealthyProblems, MR.HealthyProblems, MR.Height, MR.MedicalInsuranceNumber, MR.MedicalInsuranceUserName, MR.Medications, MR.Weight,
    		MI.Id, MI.Name
    		from Appointment AP
    		inner join [Address] AD on AD.Id = AP.AddressId
    		inner join Doctor D on D.Id = AP.DoctorId
    		inner join Patient P on P.Id = AP.PatientId
    		left join Speciality S on S.Id = D.IDEspeciality
    		left join MedicalRecord MR on MR.Id = P.MedicalRecordId
    		left join MedicalInsurance MI on MI.Id = MR.MedicalInsuranceId
    		where AP.Id = @Id
    		order by AP.Id desc";
    
    		ret = db.Query<Appointment, Address, Doctor, Patient, Speciality, MedicalRecord, MedicalInsurance, Appointment>(sql,
    			(appointment, address, doctor, patient, speciality, medicalrecord, medicalinsurance) =>
    			{
    				appointment.Address = address;
    				appointment.Doctor = doctor;
    				appointment.Patient = patient;
    				appointment.Doctor.Speciality = speciality;
    				appointment.Patient.MedicalRecord = medicalrecord;
    				appointment.Patient.MedicalRecord.MedicalInsurance = medicalinsurance;
    				return appointment;
    			}, new { Id = id }, splitOn: "Id, Id, Id, Id, Id, Id").ToList();
    	}
    	return ret;
    }
