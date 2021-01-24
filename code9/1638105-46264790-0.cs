    using NUnit.Framework;
    [TestFixture]
    public class DnaStrandTest {
        [Test]
        public void test01() {
            Assert.AreEqual("TTTT", DnaStrand.MakeComplement("AAAA"));
        }
        [Test]
        public void test02() {
            Assert.AreEqual("TAACG", DnaStrand.MakeComplement("ATTGC"));
        }
        [Test]
        public void test03() {
            Assert.AreEqual("CATA", DnaStrand.MakeComplement("GTAT"));
        }
    }
