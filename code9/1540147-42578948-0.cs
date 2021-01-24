    class Coord()
    {
       int x = 0;
       int y = 0;
       public Coord(int x,int y)
       {
         x=x;
         y=y;
       }
    }
    
    class Game()
    {
        List<Coord> coords = new List<Coord>();
        
    
        public void AddCoord(Coord c)
        {
           coords.Add(c);
           if(coords.Count>maxAmount)
           {
              coords.RemoveAt(0);
           }
        }
    }
