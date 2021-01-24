            try
            {
                testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
                TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "MyTest", null, ProgrammingLanguage.CSharp, ((string[])(null)));
                testRunner.OnFeatureStart(featureInfo);
            }
            catch (Exception e)
            {
                var typeLoadException = e as ReflectionTypeLoadException;
                var loaderExceptions = typeLoadException.LoaderExceptions;
                foreach (Exception le in loaderExceptions)
                    Console.WriteLine("LoaderException Msg = {0}", le.Message);
            }
