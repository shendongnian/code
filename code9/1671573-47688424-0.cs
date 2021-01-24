           // This will be what is returned by your slider
    int[] ar = [2,4];
     Dictionary<int, string> test = new Dictionary<int, string>()
                {
                    {1,"OK" },
                    {2,"Good"},
                    {3,"Very Good"},
                    {4,"Excellent"}
    
                };
            
                List<string> choosenquality = new List<string>();
                for(int x =ar[0];x<=ar[1];x++)
                {
                    choosenquality.Add(test[x]);
                }
    //The following will be all the products that meet good, very good, and excellent
                IEnumerable<Productclass> tested = from x in myapps join y in choosenquality where x.Quality== y select x;
                                              
