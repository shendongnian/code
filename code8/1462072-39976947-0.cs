    public static void CalculateDistanceTimeSpeed()
    {
        float speed;
        float distance;
        float time;
        
        Console.WriteLine("Find distance/speed/time based on any of the two.");
        Console.WriteLine("Enter two of the three requirements");
        Console.WriteLine();
        
        Console.WriteLine("Enter speed in km/h");
        if (!Single.TryParse(Console.ReadLine(), out speed))
            speed = 0f;
        
        Console.WriteLine("Enter distance in km");
        if (!Single.TryParse(Console.ReadLine(), out distance))
            distance = 0f;
        
        Console.WriteLine("Enter time in hour/s");
        if (!Single.TryParse(Console.ReadLine(), out time))
            time = 0f;
        
        if (speed == 0f)
        {
            speed = distance / time;
            Console.WriteLine("Required average Speed : {1}km/h for distance {0}km and time {2}hrs.", distance, speed.ToString("0.##"), time);
        }
        
        else if (distance == 0f)
        {
            distance = speed * time;
            Console.WriteLine("Distance traveled : {0}km at speed {1}km/h for {2}hrs.", distance.ToString("0.##"), speed, time);
            
        }
        
        else
        {
            time = distance / speed;
            Console.WriteLine("Travel time: {2}hrs with speed {1}km/h for distance {0}km.", distance, speed, time.ToString("0.##"));
        } 
        // add mph conversion
    }
