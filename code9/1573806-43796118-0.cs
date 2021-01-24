    public class Sum
    {
        //Returns the sum of 2 positive odd integers
        //If either of arguments is even, return -1
        //If either of arguments is negative, throw exception
        public int PositiveSumOddOnly(int a, int b)
        {
            if(a < 0 || b < 0)
                throw new InvalidArgumentException("One or more of your arguments is negative");
            if(a%2 == 0 || b%2 == 0)
                return -1;
            return a + b;
        }
    }
    [TestClass]
    public class Sum_Test
    {
        [TestMethod]
        public int PositiveSumOddOnly_ShouldThrowInvalidArgumentExecption(int a, int b)
        {
            Sum s = new Sum();
            try
            {
                int r = s.PositivesumOddOnly(1,-1);
            }
            catch(InvalidArgumentException e)
            {
                Assert.AreEqual("One or more of your arguments is negative", e.Message);
            }
        }
        [TestMethod]
        public int PositiveSumOddOnly_ShouldReturnNegativeOne(int a, int b)
        {
            Sum s = new Sum();
            int r = s.PositiveSumOddOnly(1,2);
            Assert.AreEqual(r,-1);
        }
    
        [TestMethod]
        public int PositiveSumOddOnly_ShouldReturnSumOfAandB(int a, int b)
        {
            Sum s = new Sum();
            int r = s.PositiveSumOddOnly(1,1);
            Assert.AreEqual(r,2);
        }
    }
