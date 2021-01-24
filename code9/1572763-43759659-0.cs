    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void TestSwap()
        {
            int[] sa = {3, 2};
            sa.Swap(0, 1);
            Assert.AreEqual(sa[0], 2);
            Assert.AreEqual(sa[1], 3);
        }
    }
    public static class SwapExtension
    {
        public static void Swap<T>(this T[] a, int i1, int i2)
        {
            T t = a[i1]; 
            a[i1] = a[i2]; 
            a[i2] = t; 
        }
    }
