    //the passed in person is renamed, you don't need to capture the return value
    public Person Rename(Person p){
      p.Name = "John";
      return p;
    }
    //the passed in person is not renamed, you need to capture the return value
    public Person Rename(Person p){
      p = new Person();
      p.Name = "John";
      return p;
    }
    //the passed in person is swapped out for a new one, you don't need to capture the return value
    public Person Rename(ref Person p){
      p = new Person();
      p.Name = "John";
      return p;
    }
