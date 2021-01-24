    public enum PowerType { AC, DC }
    
    public string Measure(string measurementType, PowerType pt)
    {
    	string powerString = pt == PowerType.AC ? "AC" : "DC";
    	string measurement = measurementType + powerString;
    
        io.PrintfAndFlush(measurement + "\n");
        Console.WriteLine(measurement);
        string response;
        io.Scanf("%s", out response);
        return response;
    }
