    var patients = new List<Utente> {
        new Utente { 100001, "Pedro", 914754123, "pedro@gmail.com", onsoleColor.Red },
        new Utente { 100002, "Bob", 234123542, "bob@gmail.com", onsoleColor.Green },
        new Utente { 100003, "Joe", 914753245, "joe@gmail.com", onsoleColor.Magenta }
        // etc
    };
    var patientsQueue = patients.OrderByDescending(p => p.Priority).ToList();
