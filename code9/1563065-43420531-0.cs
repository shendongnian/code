    namespace UnitTestingExamples
    {
      using System;
      using NUnit.Framework;
    
      [TestFixture]
      public class SomeTests
      {
        [Test]
        public void TestOne()
        {
          int i = 4;
          Assertion.AssertEquals( 4, i );
        }
      }
    }
