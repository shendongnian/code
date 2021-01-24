    interface IType2Factory
    {
         IType2 Create( Data theData );
    }
    class Type2Type2Factory : IType2Factory
    {
         public IType2 Create( Data theData ) => new Type2( theData );
    }
