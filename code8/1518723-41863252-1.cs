    // Code to Test
    // ThreadingExampleCode stackOverflow = new ThreadingExampleCode();
    // Thread.Sleep(new TimeSpan(1, 0, 0));
    public class ThreadingExampleCode
    {
        public static Memory memory;
        private CoprocZero zero;
        private CoprocOne one;
        private CPU cpu;
        private Thread coprocZero;
        private Thread coprocOne;
        ConcurrentQueue<uint> coprocZeroQueue = new ConcurrentQueue<uint>();
        ConcurrentQueue<uint> coprocOneQueue = new ConcurrentQueue<uint>();
        public ThreadingExampleCode()
        {
            memory = new Memory();
            memory.OnDMAZero += MemoryOnOnDmaZero;
            memory.OnDMAOne += MemoryOnOnDmaOne;
            cpu = new CPU(memory);
            zero = new CoprocZero(memory, coprocZeroQueue);
            one = new CoprocOne(memory, coprocOneQueue);
            coprocZero = new Thread(zero.RunParm);
            coprocZero.Start();
            coprocOne = new Thread(one.RunParm);
            coprocOne.Start();
            cpu.Run();
        }
        private void MemoryOnOnDmaOne(DMAEventArgs args)
        {
            coprocOneQueue.Enqueue(args.Address);
        }
        private void MemoryOnOnDmaZero(DMAEventArgs args)
        {
            coprocZeroQueue.Enqueue(args.Address);
        }
    }
    public delegate void dmazero(DMAEventArgs args);
    public delegate void dmaone(DMAEventArgs args);
    public class DMAEventArgs : EventArgs
    {
        public uint Address { get; set; }
    }
    public class Memory
    {
        public event dmazero OnDMAZero;
        public event dmaone OnDMAOne;
        public const uint CoprocZeroDMA = 1 * 1024 * 1024;
        public const uint CoprocOneDMA = 2 * 1024 * 1024;
        private byte[] memory;
        public Memory()
        {
            this.memory = new byte[(8 * 1024 * 1024)];
        }
        public byte this[uint address]
        {
            get { return memory[address]; }
            set
            {
                memory[address] = value;
                if (address == CoprocZeroDMA && OnDMAZero != null)
                    OnDMAZero(new DMAEventArgs());
                if (address == CoprocOneDMA && OnDMAOne != null)
                    OnDMAOne(new DMAEventArgs());
            }
        }
    }
    public class CPU
    {
        private Memory memory;
        public CPU(Memory inMemory)
        {
            memory = inMemory;
        }
        public void Run()
        {
            /* Start Executing Instructions */
            memory[Memory.CoprocZeroDMA] = 0x01;
            memory[Memory.CoprocOneDMA] = 0x01;
        }
    }
    public class CoprocZero
    {
        private ConcurrentQueue<uint> queueToMonitor;
        private Memory memory;
        public CoprocZero(Memory inMemory, ConcurrentQueue<uint> queue)
        {
            memory = inMemory;
            queueToMonitor = queue;
        }
        public void RunParm()
        {
            uint memoryAddress;
            while (!queueToMonitor.TryPeek(out memoryAddress)) { };
            if (queueToMonitor.TryDequeue(out memoryAddress))
            {
                Debugger.Break();
            }
        }
    }
    public class CoprocOne
    {
        private Memory memory;
        private ConcurrentQueue<uint> queueToMonitor;
        public CoprocOne(Memory inMemory, ConcurrentQueue<uint> queue)
        {
            memory = inMemory;
            queueToMonitor = queue;
        }
        public void RunParm()
        {
            uint memoryAddress;
            while (!queueToMonitor.TryPeek(out memoryAddress)) { };
            if (queueToMonitor.TryDequeue(out memoryAddress))
            {
                Debugger.Break();
            }
        }
    }
