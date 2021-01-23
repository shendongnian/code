    [TestMethod()]
    public void Get_InfoObjects_with_multiple_values_from_pipeline()
    {
        // "SELECT ..." | Get-InfoObjects ...
        //
        // arrange
        //
        string[] queries = { "SELECT * FROM ci_infoobjects WHERE si_id=23", "SELECT * FROM ci_infoobjects WHERE si_id=4" };
        Command command = new Command("Get-InfoObjects");
        using (Runspace runspace = RunspaceFactory.CreateRunspace(config))
        {
            runspace.Open();
            using (Pipeline pipeline = runspace.CreatePipeline())
            {
                foreach (string query in queries)
                {
                    pipeline.Input.Write(query);
                }
                pipeline.Commands.Add(command);
                //
                // act
                // 
                var actual = pipeline.Invoke();
                //
                // assert
                //
                Assert.AreEqual(1, actual.Count);
                Assert.IsInstanceOfType(actual[0], typeof(System.Management.Automation.PSObject));
            } // using Pipeline
        } // using // Runspace
    } // test
