        [TestMethod]
        public void IsValid_TestApplicationNumber()
        {
            MFA.Convana.BusinessLayer.ObjectModel.ApplicationNumber appno = new MFA.Convana.BusinessLayer.ObjectStore.ApplicationNumber();
            String Input;
            String exception;
            String TestCase;
            XMLHelper TestData = new XMLHelper();
            TestCase = TestData.GetTestDataString("IsValid");
            String[] arr = TestCase.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (arr.Length > 0 && TestCase.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Input = arr[i].Substring(0, arr[i].IndexOf(TestData.FieldDelimiter));
                    exception = arr[i].Substring(arr[i].IndexOf(TestData.FieldDelimiter) + 3);
                    try
                    {
                        appno.IsValid(Input);
                        Assert.IsTrue(true);                           
                    }
                    catch (Exception ex)
                    {
                      Assert.AreEqual(exception, ex.Message);
                    }
                }
            }
            else
            {
                Assert.Inconclusive("Test Skipped as no test data");
            }
        }
