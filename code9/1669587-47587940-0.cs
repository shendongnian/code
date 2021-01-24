    class TypeVar<A>
      where A: LetterAbstract
    {
      public void SetValue<B>()
        where B: A
      {
        mValue = typeof(B);
      }
      public System.Type GetValue()
      {
        return mValue;
      }
      private System.Type mValue;
    }
    var x =new TypeVar<LetterAbstract>();
    x.SetValue<LetterA>(); // valid
    x.SetValue<string>(); // invalid
    x.GetValue(); // get the type
