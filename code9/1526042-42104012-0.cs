    public Person PersonMapper(string[] input)
    {
        return new Person {
            FirstName = input[0],
            LastName = input[1],
            Phone = input[2],
            Age = Convert.ToInt32(input[3])
        };
    }
