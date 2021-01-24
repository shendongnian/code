    public List<PatientMasterDataViewModel> GetPatientData(string name)
    {
        using (var ctx = new ApplicationDbContext())
        {
            List<PatientMasterDataViewModel> patientdata = new List<PatientMasterDataViewModel>();
            var items = ctx.Patients.Where(x => x.Name.Contains(name)).ToList();
            for (int i = 0; i < items.Count; i++)
            {
                patientdata.Add(new PatientMasterDataViewModel
                {
                    Id = items[i].Id,
                    Name = items[i].Name,
                    Birthday = items[i].Date_of_Birthday
                });
            }
            return patientdata;
        }
    }
