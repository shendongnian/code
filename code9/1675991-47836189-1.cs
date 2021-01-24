    class Test 
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }
    
    var tests = new List<Test> { /* ... your data here ... */ };
    
    var modifiedTests = tests.Select(test => { test.Name = "MODIFIED"; return test; });
    // this actually executes above query and modifies your original items in the list:
    var modifiedMaterialized = modifiedTests.ToList();
