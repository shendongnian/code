        public const int N = 33 * 1024;
        public const int threadsPerBlock = 256;
        public const int blocksPerGrid = 32;
        public static void Main()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            CudafyModule km = CudafyTranslator.Cudafy();
            GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId);
            gpu.LoadModule(km);
            string Text = "";
            int iterations = 1000000;
            double Value;
            double[] dev_Value = gpu.Allocate<double>(iterations * sizeof(double));
            gpu.Launch(blocksPerGrid, threadsPerBlock).SumOfSines(iterations, dev_Value);
            gpu.CopyFromDevice(dev_Value, out Value);
            watch.Stop();
            Text = watch.Elapsed.TotalSeconds.ToString();
            Console.WriteLine("The process took a total of: " + Text + " Seconds");
            Console.WriteLine(Value);
            Console.Read();
            gpu.FreeAll();
        }
        [Cudafy]
        public static void SumOfSines(GThread thread, int _iterations, double[] Value)
        {
            int threadID = thread.threadIdx.x + thread.blockIdx.x * thread.blockDim.x;
            int numThreads = thread.blockDim.x * thread.gridDim.x;
            if (threadID < _iterations){
                for (int i = threadID; i < _iterations; i += numThreads)
                {
                    double _degAsRad = Math.PI / 180;
                    Value[i] = 0.0;
                    for (int a = 0; a < 100; a++)
                    {
                        double angle = (double)a * _degAsRad;
                        Value[i] += Math.Sin(angle);
                    }
                }
            }
        }
