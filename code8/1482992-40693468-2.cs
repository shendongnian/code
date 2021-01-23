    /// <summary>The name sez it all</summary>
    public struct MyStruct
    {
      /// <summary>implicit</summary>
      /// <param name="i">an int</param>
      public static implicit operator MyStruct( int i )
      {
        return new MyStruct( );
      }
      /// <summary>Thus and so</summary>
      public static bool operator ==( MyStruct a, MyStruct b )
      {
        return false;
      }
      
      /// <summary>Thus and so</summary>
      public static bool operator !=( MyStruct a, MyStruct b )
      {
        return true;
      }
      
      /// <summary>Thus and so</summary>
      public override bool Equals( object obj )
      {
        return base.Equals( obj );
      }
      
      /// <summary>Thus and so</summary>
      public override int GetHashCode( )
      {
        return base.GetHashCode( );
      }
      
      /// <summary>Thus and so</summary>
      public override string ToString( )
      {
        return base.ToString( );
      }
    }
