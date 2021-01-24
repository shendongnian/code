    public int Age { get { return age; } } // no setter
    public bool SetAge(int newAge)
    {
        if (newAge < 0) 
        {
            Console.WriteLine("Wrong age: " + newAge);
            return false;
        }
        
        age = newAge;
        return true;
    }
    ....
    if (dog.SetAge(-10))
    {
        Console.WriteLine("Age successfully set to " + dog.Age);
    }
