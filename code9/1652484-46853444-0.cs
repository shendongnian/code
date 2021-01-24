    namespace Test.TestTemplate
    {
        [TestFixture]
        [TestCaseSource(typeof(TestTemplateData), "HasAccessData")]
        // Make the type as bool so you can run it against the NUnit .Returns
        public bool HAS_ACCESS_<#= "TestName" #>(string stringParameter, Action actionParameter)
        {
            <#= MyAction.Invoke() #>
            // Do something here with the parameters...
            // Remember you have to return here so the .Returns can assert against it.
            // No need to do Assert
        }
    }
