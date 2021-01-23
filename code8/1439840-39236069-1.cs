    [Test]
    [TestCaseSource(nameof( Exceptions ))]
    public void UnitTest<T>( T exception ) where T : Exception, new(){
         _businessService.Setup(x=>x.DoWork).Throws.InstanceOf<T>();
           //verify that when we called DoWork, that the logic inside of one of the catches was executed
        }
