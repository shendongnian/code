    [TestFixture]
    public class WeakListTests
    {
        [Test]
        public static void PurgeTest()
        {
            var myList = new WeakList<string>();
            // construct strings like this to prevent interning
            string s1 = new string(new[] { 'h', 'e', 'l', 'l', 'o' });
            string s2 = new string(new[] { 'h', 'e', 'l', 'l', 'o', '2' });
            // this string can be interned, we don't want it to be collected anyway
            string s3 = "hello world 3";            
            myList.Add(s1);
            myList.Add(s2);
            myList.Add(s3);
            // set to null for that to work even in application built with "Debug"
            // in Release it will work without setting to null
            s1 = null;
            s2 = null;
            // force GC collection
            GC.Collect(2, GCCollectionMode.Forced);            
            // now s1 and s2 are away
            myList.Purge();
            // invoke your enumerator
            var left = myList.ToArray();            
            // should contain 1 item and that item should be s3
            Assert.That(left.Length == 1);
            Assert.AreEqual(s3, left[0]);            
        }
    }
