    class Program
    {
        static string CalculateKernel
        {
            get
            {
                return @"
                kernel void Calc(global int* offsets, global int* lengths, global double* doubles, double periodFactor) 
                {
                    int id = get_global_id(0);
                    int start = offsets[id];
                    int length = lengths[id];
                    int end = start + length;
                    double sum = doubles[start];
                    
                    for(int i = start; i < end; i++)
                    {
                        sum = sum + periodFactor * ( doubles[i] - sum );
                        doubles[i] = sum;
                    }
                }";
            }
        }
        public static double[] Calculate(double[] num, int period)
        {
            var final = new double[num.Length];
            double sum = num[0];
            double coeff = 2.0 / (1.0 + period);
            for (int i = 0; i < num.Length; i++)
            {
                sum += coeff * (num[i] - sum);
                final[i] = sum;
            }
            return final;
        }
        static void Main(string[] args)
        {
            int Devices = AcceleratorDevice.All.Length;
            foreach (var AcceleratorDevice in AcceleratorDevice.All)
            {
                Console.WriteLine(AcceleratorDevice);
            }
            int maxElements = 10000;
            int numArrays = 10000;
            int computeCores = 2048;
            double[][] sets = new double[numArrays][];
            using (Timer("Generating Data"))
            {
                Random elementRand = new Random(1);
                for (int i = 0; i < numArrays; i++)
                {
                    sets[i] = GetRandomDoubles(elementRand.Next((int)(maxElements * 0.9), maxElements), randomSeed: i);
                }
            }
            int period = 14;
            double[][] singleResults;
            using (Timer("CPU Single Thread"))
            {
                singleResults = CalculateCPU(sets, period);
            }
            double[][] parallelResults;
            using (Timer("CPU Parallel"))
            {
                parallelResults = CalculateCPUParallel(sets, period);
            }
            if (!AreTheSame(singleResults, parallelResults)) throw new Exception();
            double[][] gpuResults;
            using (Timer("Running GPU"))
            {
                gpuResults = CalculateGPU(computeCores, sets, period);
            }
            if (!AreTheSame(singleResults, gpuResults)) throw new Exception();
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
        public static bool AreTheSame(double[][] a1, double[][] a2)
        {
            if (a1.Length != a2.Length) return false;
            for (int i = 0; i < a1.Length; i++)
            {
                var ar1 = a1[i];
                var ar2 = a2[i];
                if (ar1.Length != ar2.Length) return false;
                for (int j = 0; j < ar1.Length; j++)
                    if (Math.Abs(ar1[j] - ar2[j]) > 0.0000001) return false;
            }
            return true;
        }
        public static double[][] CalculateGPU(int partitionSize, double[][] sets, int period)
        {
            ComputeContextPropertyList cpl = new ComputeContextPropertyList(ComputePlatform.Platforms[0]);
            ComputeContext context = new ComputeContext(ComputeDeviceTypes.Gpu, cpl, null, IntPtr.Zero);
            ComputeProgram program = new ComputeProgram(context, new string[] { CalculateKernel });
            program.Build(null, null, null, IntPtr.Zero);
            ComputeCommandQueue commands = new ComputeCommandQueue(context, context.Devices[0], ComputeCommandQueueFlags.None);
            ComputeEventList events = new ComputeEventList();
            ComputeKernel kernel = program.CreateKernel("Calc");
            double[][] results = new double[sets.Length][];
            EasyCL cl = new EasyCL() { Accelerator = AcceleratorDevice.GPU };
            cl.LoadKernel(CalculateKernel);
            double periodFactor = 2d / (1d + period);
            Stopwatch sendStopWatch = new Stopwatch();
            Stopwatch executeStopWatch = new Stopwatch();
            Stopwatch recieveStopWatch = new Stopwatch();
            int offset = 0;
            while (true)
            {
                int first = offset;
                int last = Math.Min(offset + partitionSize, sets.Length);
                int length = last - first;
                var merged = Merge(sets, first, length);
                sendStopWatch.Start();
                ComputeBuffer<int> offsetBuffer = new ComputeBuffer<int>(
                    context,
                    ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer,
                    merged.Offsets);
                ComputeBuffer<int> lengthsBuffer = new ComputeBuffer<int>(
                    context,
                    ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer,
                    merged.Lengths);
                ComputeBuffer<double> doublesBuffer = new ComputeBuffer<double>(
                    context,
                    ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer,
                    merged.Doubles);
                kernel.SetMemoryArgument(0, offsetBuffer);
                kernel.SetMemoryArgument(1, lengthsBuffer);
                kernel.SetMemoryArgument(2, doublesBuffer);
                kernel.SetValueArgument(3, periodFactor);
                sendStopWatch.Stop();
                executeStopWatch.Start();
                commands.Execute(kernel, null, new long[] { merged.Lengths.Length }, null, events);
                executeStopWatch.Stop();
                using (var pin = Pinned(merged.Doubles))
                {
                    recieveStopWatch.Start();
                    commands.Read(doublesBuffer, false, 0, merged.Doubles.Length, pin.Address, events);
                    commands.Finish();
                    recieveStopWatch.Stop();
                }
                for (int i = 0; i < merged.Lengths.Length; i++)
                {
                    int len = merged.Lengths[i];
                    int off = merged.Offsets[i];
                    var res = new double[len];
                    Array.Copy(merged.Doubles,off,res,0,len);
                    results[first + i] = res;
                }
                offset += partitionSize;
                if (offset >= sets.Length) break;
            }
            Console.WriteLine("GPU CPU->GPU: " + recieveStopWatch.ElapsedMilliseconds + "ms");
            Console.WriteLine("GPU Execute: " + executeStopWatch.ElapsedMilliseconds + "ms");
            Console.WriteLine("GPU GPU->CPU: " + sendStopWatch.ElapsedMilliseconds + "ms");
            return results;
        }
        public static PinnedHandle Pinned(object obj) => new PinnedHandle(obj);
        public class PinnedHandle : IDisposable
        {
            public IntPtr Address => handle.AddrOfPinnedObject();
            private GCHandle handle;
            public PinnedHandle(object val)
            {
                handle = GCHandle.Alloc(val, GCHandleType.Pinned);
            }
            public void Dispose()
            {
                handle.Free();
            }
        }
        public class MergedResults
        {
            public double[] Doubles { get; set; }
            public int[] Lengths { get; set; }
            public int[] Offsets { get; set; }
        }
        public static MergedResults Merge(double[][] sets, int offset, int length)
        {
            List<int> lengths = new List<int>(length);
            List<int> offsets = new List<int>(length);
            for (int i = 0; i < length; i++)
            {
                var arr = sets[i + offset];
                lengths.Add(arr.Length);
            }
            var totalLength = lengths.Sum();
            double[] doubles = new double[totalLength];
            int dataOffset = 0;
            for (int i = 0; i < length; i++)
            {
                var arr = sets[i + offset];
                Array.Copy(arr, 0, doubles, dataOffset, arr.Length);
                offsets.Add(dataOffset);
                dataOffset += arr.Length;
            }
            return new MergedResults()
            {
                Doubles = doubles,
                Lengths = lengths.ToArray(),
                Offsets = offsets.ToArray(),
            };
        }
        public static IDisposable Timer(string name)
        {
            return new SWTimer(name);
        }
        public class SWTimer : IDisposable
        {
            private Stopwatch _sw;
            private string _name;
            public SWTimer(string name)
            {
                _name = name;
                _sw = Stopwatch.StartNew();
            }
            public void Dispose()
            {
                _sw.Stop();
                Console.WriteLine("Task " + _name + ": " + _sw.Elapsed.TotalMilliseconds + "ms");
            }
        }
        public static double[][] CalculateCPU(double[][] arrays, int period)
        {
            double[][] results = new double[arrays.Length][];
            for (var index = 0; index < arrays.Length; index++)
            {
                var arr = arrays[index];
                results[index] = Calculate(arr, period);
            }
            return results;
        }
        public static double[][] CalculateCPUParallel(double[][] arrays, int period)
        {
            double[][] results = new double[arrays.Length][];
            Parallel.For(0, arrays.Length, i =>
             {
                 var arr = arrays[i];
                 results[i] = Calculate(arr, period);
             });
            return results;
        }
        static double[] GetRandomDoubles(int num, int randomSeed)
        {
            Random r = new Random(randomSeed);
            var res = new double[num];
            for (int i = 0; i < num; i++)
                res[i] = r.NextDouble() * 0.9 + 0.05;
            return res;
        }
    }
