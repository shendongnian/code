    void Main()
    {
    	int numberOfHourses = 10;
    	var hourses = new List<Horse>();
    	int afstand = 70;
    	Random randomizer = new Random();
    	
    	for (int i = 0; i < numberOfHourses; i++)
    	{
    		var horse = new Horse(i);
    		horse.setSpeed(randomizer.Next(afstand / 7, afstand/5)); 
    		hourses.Add(horse);
    	}
    	
    	for (int i = 0; i < numberOfHourses; i++)
    	{
    		// get your hourse speed here:
    		var speed = hourses[i].getSpeed();
    		Console.WriteLine(speed);
    	}
    }
    
    class Horse
    {
        int nummer;     //Number
        int snelheid;   //Speed
        int afstand;    //Distance
    
        public Horse()
        {
            nummer = 0;
        }
        public Horse(int num)
        {
            nummer = num;
        }
    
        public void setSpeed(int speed)
        {
            snelheid = speed;
        }
    
        public void setDistance(int distance)
        {
            afstand = distance;
        }
    
        public int getDistance()
        {
            return afstand;
        }
    
        public int getSpeed()
        {
            return snelheid;
        }
    
        public int getNummer()
        {
            return nummer;
        }
    }
