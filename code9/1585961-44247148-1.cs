    var patients = new List<Patient> {
        new Patient { 100001, "Pedro", 914754123, "pedro@gmail.com", PatientPriority.Normal },
        new Patient { 100002, "Bob", 234123542, "bob@gmail.com", PatientPriority.Low },
        new Patient { 100003, "Joe", 914753245, "joe@gmail.com", PatientPriority.Extra }
        // etc
    };
    var patientsQueue = patients.OrderByDescending(p => p.Priority).ToList();
