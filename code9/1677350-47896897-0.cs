    public static Extensions
    {
        public static void CompareWithExpected(this <type> value, <type> expected)
        {
            Assert.AreEqual(expected.Property1, value.Property1, "Property1 did not match expected";
            Assert.AreEqual(expected.Property2, value.Property2, "Property2 did not match expected";
        }
    }
