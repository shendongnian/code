        [TestCase(new int[] { 0, 1, 2, 3 }, true)]
        [TestCase(new int[] { 0, 3, 4 }, false)]
        [TestCase(new int[] { 4, 4, 4 }, true)]
        [TestCase(new int[] { 6, 6, 8, 8 }, true)]
        [TestCase(new int[] { 5, 4, 4, 4, 3 }, false)]
        [TestCase(new int[] { 9, 9 }, false)]
        [TestCase(new int[] { 0, 2 }, false)]
        [TestCase(new int[] { }, false)] // bug: SkipWhile skips all master's items, so master[] { } == sub[] { } is true;
        public void MethodToTest(int[] sub, bool expected)
        {
            var master = new int[] { 0, 1, 2, 3, 4, 4, 4, 5, 6, 6, 8, 8 };
            var result = master.SkipWhile((x, i) => !x.Equals(sub[0]) && !master.Skip(i).Take(sub.Length).SequenceEqual(sub))
                .Take(sub.Length).SequenceEqual(sub);
            Assert.AreEqual(expected, result);
        }
