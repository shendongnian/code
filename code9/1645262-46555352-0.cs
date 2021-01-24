        private static void Run()
        {
            var input = Gpu.Default.AllocateDevice<byte>(100);
            var deviceptr = input.Ptr;
            Gpu.Default.For(0, input.Length, i => Worker(i, deviceptr));
            Console.WriteLine(string.Join(", ", Gpu.CopyToHost(input)));
        }
        private static void Worker(int ix, deviceptr<byte> array)
        {
            array[ix] = 10;
        }
