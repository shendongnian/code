    public void GetAll()
    {
       List<double> doubles = new List<double>();
       var parts = buff.Split();
       if(parts.Length == 2)
       {
           double d;
           if(double.TryParse(parts[1], out d)
               doubles.Add(d);
       }
    }
