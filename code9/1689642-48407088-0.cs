    using System;
    using System.Management.Automation;
    
    namespace TestPSObject
    {
      // This will be our parameter type
      public class TestObject {}
    
      // This will be our reference type test cmdlet
      [Cmdlet(VerbsDiagnostic.Test, "PSObjectByRef")]
      public class TestPSObjectByRefCommand : Cmdlet
      {
        [Parameter(Mandatory=true)]
        public TestObject TestObject
        {
          get { return testObject; }
          set { testObject = value; }
        }
        private TestObject testObject;
    
        protected override void ProcessRecord()
        {
          // If this works, we should receive an object with
          // identical psextended properties
          WriteObject(PSObject.AsPSObject(this.TestObject));
        }
      }
    
      // This will be our value type test cmdlet
      [Cmdlet(VerbsDiagnostic.Test, "PSObjectByValue")]
      public class TestPSObjectByValueCommand : Cmdlet
      {
        [Parameter(Mandatory=true)]
        public DateTime DateTime
        {
          get { return dateTime; }
          set { dateTime = value; }
        }
        private DateTime dateTime;
    
        protected override void ProcessRecord()
        {
          // If this works, we should receive an object with
          // identical psextended properties (hint: we won't)
          WriteObject(PSObject.AsPSObject(this.DateTime));
        }
      }
    }
