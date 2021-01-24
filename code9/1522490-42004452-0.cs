    public async Task<ObservableCollection<Person>> GetAllPersonAsync()
    { 
      using (var context = new Db())
      {
        // This code wasn't shown in the question.
        // But from the compiler warning, it was probably using something like
        //   var people = People.ToList();
        //   return new ObservableCollection<Person>(people);
        // And the async version should be:
        var people = await People.ToListAsync();
        return new ObservableCollection<Person>(people);
      }
    }
