    var queryResult = from p in patients
                      join i in illnesses on p.id equals i.id
                      into allPatientIllnesses
                      select new
                      {
                          Patient = p,
                          IlnessList = allPatientIllnesses.ToList()
                      };
    foreach (var item in queryResult)
    {
        Citizen patient = item.Patient;
        string illnesses = string.Join(",", item.IlnessList.Select(i => i.illnessName));
    }
