    public void GetAll()
    {
       List<double> doubles = new List<double>();
       foreach(var line in buff.Split('\n')
       {
           var parts = line.Split();
           if(parts.Length == 3)
           {
               double d;
               if(double.TryParse(parts[2], out d)
                   doubles.Add(d);
           }
        }
    }
