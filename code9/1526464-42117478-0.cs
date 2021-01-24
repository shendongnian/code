      using (var context = new EntityTesting.TesterEntities())
      {
        var nPerson = new tePerson { FirstName = "Test", LastName = "Tester" };
        context.tePerson.Add(nPerson);
        context.SaveChanges();
      }
