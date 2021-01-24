    using Alea;
    using Alea.CSharp;
    using NUnit.Framework;
        public static void RecursionTestFunc(deviceptr<int> a)
        {
            if (a[0] == 0)
            {
                a[0] = -1;
            }
            else
            {
                a[0] -= 1;
                RecursionTestFunc(a);
            }
        }
        public static void RecursionTestKernel(int[] a)
        {
            var tid = threadIdx.x;
            var ptr = DeviceFunction.AddressOfArray(a);
            ptr += tid;
            RecursionTestFunc(ptr);
        }
        [Test]
        public static void RecursionTest()
        {
            var gpu = Gpu.Default;
            var host = new[] {1, 2, 3, 4, 5};
            var length = host.Length;
            var dev = gpu.Allocate(host);
            gpu.Launch(RecursionTestKernel, new LaunchParam(1, length), dev);
            var actual = Gpu.CopyToHost(dev);
            var expected = new[] {-1, -1, -1, -1, -1};
            Assert.AreEqual(expected, actual);
            Gpu.Free(dev);
        }
