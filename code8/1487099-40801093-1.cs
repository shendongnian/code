    foreach (Car car in carColl)
    {    
        foreach (string propName in car.propNames)
        {
            // It is what I want to do. But car.propName don't work
            Console.WriteLine(propName);
        }
    }
