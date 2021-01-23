    public IEnumerable<PracownikDane> GetPracownik(string imie) { 
      using (NORTHWNDEntities database = new NORTHWNDEntities())
        {
          var query = from pros in database.Employees
                            where pros.Title == imie
                            select pros;
    
          var EmployeeList = new List<PracownikDane>();
          foreach(var pp in query)
          {
            EmployeeList.Add(new PracownikDane()
            {
             Tytul = pp.Title,
             Imie = pp.FirstName,
             Nazwisko = pp.LastName,
             Kraj = pp.Country,
             Miasto = pp.City,
             Adres = pp.Address,
             Telefon = pp.HomePhone,
             WWW = pp.PhotoPath
            });        
          }
        return EmployeeList;
    }
