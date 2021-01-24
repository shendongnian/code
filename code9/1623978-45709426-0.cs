    NameGenerator nameGen = new NameGenerator();
    for (int i = 0; i < 100; i++)
    {
       Human h = new Human(nameGen.generateName(4, 8), nameGen.generateName(4, 12));
       worldHumans.Add(h);
       newWorldHumans.Add(h);
    }
