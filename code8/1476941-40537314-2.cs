    if (p is Success<Person>) {
      Person p = ((Success<Person>)p).Value;
      Debug.WriteLine("Value is Success, and the person is " + p.FirstName + " " + p.Surname);
    } else {
      Exception ex = ((Failure<Person>)p).Value;
      Debug.WriteLine("Value is Failure, and the message is " + ex.Message);
    }
