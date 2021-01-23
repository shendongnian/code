    sealed class Path 
    {
      private Path() { }
      private Path(Coordinate first, Path rest)
      {
        this.first = first;
        this.rest = rest;
      }
      public static readonly Path Empty = new Path();
      private Coordinate first;
      private Path rest;
      public bool IsEmpty => this == Empty;
      public Coordinate First 
      { 
        get  
        {
          if (this.IsEmpty) throw new Exception("empty!");
          return first;
        }
      }
      public Path Rest
      {   
        get 
        {
          if (this.IsEmpty) throw new Exception("empty!");
          return rest;
        }
      }
      public Path Append(Coordinate c) => new Path(c, this);
      public IEnumerable<Coordinate> Coordinates()
      {
        var current = this;
        while(!current.IsEmpty)
        {
          yield return current;
          current = current.Rest;
        }
      }
    }
