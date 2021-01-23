    Car car3 = new Car 
    {
        Name = "E",
        Type = "F"
    };
    
    Car car2 = new Car 
    {
        Name = "C",
        Type = "D",
        innerChild = car3
    };
    
    Car car1 = new Car 
    {
        Name = "A",
        Type = "B",
        innerChild = car2
    };
