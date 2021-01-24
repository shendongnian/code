    public void GetAll()
    {
       List<double> doubles = new List<double>();
       var parts = buff.Split();
       if(parts.Length == 3)
       {
           double d;
           if(double.TryParse(parts[2], out d)
               doubles.Add(d);
       }
    }
