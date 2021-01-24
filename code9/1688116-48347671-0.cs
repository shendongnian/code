        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.ToString().Equals("Passed")
            {
                // Run Script to Drop Table
                // Confirm Table Dropped
                // Close Driver
                driver.Close();
                Console.WriteLine("Table Drop Confirmed and Driver Closed.");
            } else {
                Console.WriteLine("Test did not pass, Table not dropped.");
                driver.Close();
                Console.WriteLine("Driver Closed.");
            }
        }
