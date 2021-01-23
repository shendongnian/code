       public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new int[] { 0, 1, 5, 7 }, 2).SetName("1");
                yield return new TestCaseData(new int[] { 0, 1, 2, 3, 4 },5).SetName("2");
                yield return new TestCaseData(new int[] { 1, 2, 3, 4 },0).SetName("3");
                yield return new TestCaseData(new int[] { -2, -1, 1, 2, 3, 4 }, 0).SetName("4");
                yield return new TestCaseData(new int[] { -2, -1, 0, 1, 2, 3, 4 },0).SetName("5");
                yield return new TestCaseData(new int[] { 0 },1).SetName("6");
                yield return new TestCaseData(new int[] { },0).SetName("7");
               
            }
        }
        [TestCaseSource("TestCases")]
        public void Test(int[] items, int expected ) {
            Assert.AreEqual(expected, GetGap(items));
        }
