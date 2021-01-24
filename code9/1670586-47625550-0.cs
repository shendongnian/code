    static void(string[] args)
    {
      var list = new List<Person>();
      var person = new Person();
      var arr = line.split(','); //line = "test1,test2,test3
      person.Name = arr[0];
      person.SurName = arr[1];
      person.DateOfBirth = arr[2];
      list.Add(person);
    }
