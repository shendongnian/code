    private void ATF_Main_Load(object sender, EventArgs e)
        {
            // Add reference to tests DLL and load it here by name
            Assembly testAssembly = Assembly.Load("Program.Tests");
            package = new TestPackage(testAssembly.Location);
            package.AddSetting("Working Directory", Environment.CurrentDirectory);
        }
