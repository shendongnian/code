    public void Update(People people)
    {
         using (var dbContext = new MyDbContext())
         {
              var foundPeople = people.Find(people.Id);
              foundPeople.Name = people.Name;
              foundPeople.NameWithoutDiacritics = people.Name
                   .ToUpper()
                   .RemoveDiacritics();
              ...
              dbContext.SaveChanges();
         }
    }
