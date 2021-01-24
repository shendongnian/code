     [TestFixture]
        internal class MaskTests
        {
            private string input = "40770058698999513265";
            private char maskChar = 'X';
            private IStringMask mask;
    
            [SetUp]
            public void Initiate()
            {
                mask = new StringMask(input, maskChar);
            }
    
            [Test]
            public void MaskShowLast()
            {
                var output = mask.ShowLast(10);
                Console.WriteLine(output);
                Assert.AreEqual("XXXXXXXXXX8999513265", output.ToString());
            }
    
         
    
            [Test]
            public void MaskInTheMiddle()
            {
                var output = mask.ShowLast(5).ShowFirst(5);
                Console.WriteLine(output);
                Assert.AreEqual("40770XXXXXXXXXX13265", output.ToString());
            }
    
            [Test]
            public void MaskInTheMiddleTooShort()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => mask.ShowLast(0).ShowFirst(0));
            }
    
            [Test]
            public void MaskInTheMiddleTooLong()
            {
                Assert.Throws<ArgumentOutOfRangeException>(()=> mask.ShowLast(500).ShowFirst(500));
            }
    
            [Test]
            public void MaskAtTheEnd()
            {
                var output = mask.ShowFirst(10);
                Console.WriteLine(output);
                Assert.AreEqual("4077005869XXXXXXXXXX", output.ToString());
    
            }
        }
