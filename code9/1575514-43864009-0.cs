    public void TestWithNegatives()
    {
    	using (StringWriter sw = new StringWriter())
        {
            Console.SetError(sw);
            List<int> list = MyMethod();
            // Check output in "Error":
            Assert.IsFalse(string.IsNullOrEmpty(sw.ToString())); 
    	}
    }
