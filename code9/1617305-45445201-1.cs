    void Main()
    {
    	var daysOfWeek = GetDaysOfWeek();
    	MethodA(daysOfWeek);
    	MethodB(daysOfWeek);
    }
    
    void MethodA(string[] daysOfWeek)
    {
        StringBuilder sb = new StringBuilder();
    
        for (int i = 0; i < daysOfWeek.Length; i++)
        {
            sb.Append(daysOfWeek[i]);
    		
            if (i < daysOfWeek.Length - 2)
                sb.Append(", ");
            else if (i == daysOfWeek.Length - 2)
                sb.Append(" and ");
        }
    
        Console.WriteLine(sb.ToString());
    }
    
    void MethodB(string[] daysOfWeek)
    {
        StringBuilder sb = new StringBuilder();
    
        for (int i = 0; i < daysOfWeek.Length; i++)
        {
            sb.Append(daysOfWeek[i]);
    		
            if (i < daysOfWeek.Length)
                sb.Append(", ");
        }
    
        Console.WriteLine(sb.ToString());
    }
    
    public string[] GetDaysOfWeek()
    {
        return (new List<string>{"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}).ToArray() ;
    }
