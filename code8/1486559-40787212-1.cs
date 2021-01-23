    class Test
    {
        public string FString { get; set; }
        public int FInt { get; set; }
    }
    /* ... */
    List<Test> x = new List<Test>
    {
        new Test {FString = "A", FInt = 10}, new Test {FString = "B", FInt = 20}
    };
