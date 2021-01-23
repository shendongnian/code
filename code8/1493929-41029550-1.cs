    public static List<Pair> ConvertToPairs(int[,] dieValues) 
    {
       var query = from int item in dieValues
                   select item;
    
       var p1Rolls = query.ToList();
       List<Pair> pairs = new List<Pair>( p1Rolls.Count );
       for( int i = 0; i < 4; i += 2 ) 
       {
          pairs.Add( new Pair() { FirstDie = p1Rolls[ i ], SecondDie = p1Rolls[ i + 1 ] } );
       }
    
       return pairs;
    }
