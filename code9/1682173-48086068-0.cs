    public void AddToPatient(Patient newPatient)
		{
			SMBASchedulerEntities dbContext = new SMBASchedulerEntities();
			if (newPatient.ID.ToString() != "0")
			{//Update the record
				Patient updatePatient = dbContext.Patients.Single(p => p.ID == newPatient.ID);
				updatePatient.FirstName = newPatient.FirstName;
				updatePatient.LastName = newPatient.LastName;
				...
                ...
				dbContext.SubmitChanges();
			}
			else
			{//Insert a new record
				Patient insertPatient = new Patient();
				insertPatient.FirstName = newPatient.FirstName;
				insertPatient.LastName = newPatient.LastName;
				...
                ...
				dbContext.Patients.InsertOnSubmit(insertPatient);
				dbContext.SubmitChanges();
			}
		}
