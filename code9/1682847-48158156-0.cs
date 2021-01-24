      public string InterceptorToString()
      {
         return "Injected Text";
      }
      [Test]
      [Category( "Interceptor" )]
      public void InjectionTest()
      {
         MyObject obj = new MyObject();
         string objString1 = obj.ToLongString();
         string intString1 = InterceptorToString(); //returns "Injected Text"
       
         Interceptor.Inject( obj.ToLongString, InterceptorToString );
         string objString2 = obj.ToLongString(); //returns "Injected Text"
         string intString2 = InterceptorToString();
         Interceptor.Inject( obj.ToLongString, InterceptorToString );
         string objString3 = obj.ToLongString();
         string intString3 = InterceptorToString(); //returns "Injected Text"
         Assert.That( objString2, Is.Not.EqualTo( intString2 ) );
         Assert.That( objString3, Is.Not.EqualTo( intString3 ) );
         Assert.That( objString2, Is.EqualTo( "Injected Text" ) );
      }
