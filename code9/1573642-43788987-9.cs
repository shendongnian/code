    IList<IAnimal> animals = new List<Animal>();
    animals.Add( new Cat() );
    animals.Add( new Bird() );
    int totalLegs = 0;
    foreach (var animal in animals) {
        totalLegs += animal.GetLegs(); // or totalLegs += GetLegs( animal );
    }
    Console.WriteLine( totalLegs ); // 6
