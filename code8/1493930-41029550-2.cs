    class Program 
    {
       static void Main(string[] args) 
       {
    
          int[,] dieValue1 = { { 1, 2 }, { 3, 4 } };
          int[,] dieValue2 = { { 1, 2 }, { 6, 4 } };
    
    
    
          var p1Rolls = ConvertToPairs( dieValue1 );
          var p2Rolls = ConvertToPairs( dieValue2 );
    
          foreach( var item in p1Rolls.Except( p2Rolls ) ) 
          {
    
             Console.WriteLine( "Player 1 has [{0}, {1}] which player 2 does not.", item.FirstDie, item.SecondDie );
          }
    
          var result = LoadComment( 1, null );
          Console.ReadKey();
    
       }
    
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
    }
