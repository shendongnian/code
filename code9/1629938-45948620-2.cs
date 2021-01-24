    void AddAccount(string name, string surname, DateTime age, string phone, string username, string pwd)
    {
         Person person = new Person
         {
            Name = name,
            Surname = surname,
            Age = age,
            Phone = phone,
            Username = username,
            Password = password
         }
         AddAccount(person);
    }
    
    private void AddAccount(Person person)
    {
         // Codes...
    
         // I want to call this method again.
         AddAccount(person);
    }
