    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0) throw new Exception("Invalid age: " + value);
            age = value;
        }
    }
    ...
    try
    {
        dog.Age = -10;
        Console.WriteLine(dog.Age);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error setting age: " + ex.Message);
    }
