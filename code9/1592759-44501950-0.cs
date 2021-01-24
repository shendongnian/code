    using (var dataContext = new BAKKEntities())
    {
        IEnumerable<Klienci> clients = dataContext.Klienci
            .Select(client => new Klienci()
            {
                Imie = client.Imie,
                Nazwisko = client.Nazwisko,
                Adres = client.Adres,
                Telefon = client.Telefon,
                Email = client.Email,
                Status = client.Status,
             });
         myBindingsource.DataSource = new BindingList<Klienci>(clients.ToList())
    }
