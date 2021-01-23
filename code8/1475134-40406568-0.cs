    public void CalledMethod(List<Animal> animals)
    { 
        animals.Add(new Dog()); 
        // error! you've tried to insert a dog into List<Horse>
    }
    public void CallingMethod()
    {
        var horses = new List<Horse>() {
          new Horse("Silver", 65, 70),
          new Horse("Tucker", 60, 68)
        };
        CalledMethod(horses);
        string result = horses[2].RideOrDoSomeOtherHorseOnlyThings(); // it would be strange
    }
