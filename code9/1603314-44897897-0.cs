    MFA.Convana.BusinessLayer.ObjectModel.ApplicationNumber appno 
        = new MFA.Convana.BusinessLayer.ObjectStore.ApplicationNumber();
    String Input;
    String Output;
    String TestCase;
    XMLHelper TestData = new XMLHelper();
    TestCase = TestData.GetTestDataString("IsValid");
    String[] arr = TestCase.Split(new string[] { Environment.NewLine },
            StringSplitOptions.None);
    if (arr.Length > 0)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Input = arr[i].Substring(0, arr[i].IndexOf(TestData.FieldDelimiter));
            Output = arr[i].Substring(arr[i].IndexOf(TestData.FieldDelimiter) + 3);
            Assert.AreEqual(appno.IsValid(Input), Convert.ToBoolean(Output));//Error in this line
        }
    }
