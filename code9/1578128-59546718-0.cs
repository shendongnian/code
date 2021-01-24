    [TestFixture]
    public void MyTestClass()
    {
        [Test]
        public void TestMethod1()
        {
            MyMatrix m = new MyMatrix();
            // Method1() modifies the data...
            m.Method1(_data);
        }
        [Test]
        public void TestMethod2()
        {
            MyMatrix m = new MyMatrix();
            // here you test with modified data and, in general, cannot expect success
            m.Method2(_data);
        }
        // the data to test with
        private double[] _data = new double[1, 2, 3, 4]{};
    }
