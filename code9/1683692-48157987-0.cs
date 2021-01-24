    static void Main(string[] args)
    {
        Console.WriteLine("Starting reading data");
        var reader = new LinesReader();
        Console.WriteLine("Reading data...");
        try
        {
            reader.Start();
            Console.ReadKey();
        }
        finally
        {
            reader.Stop();
        }
        foreach (var line in reader.ValidLines)
        {
            line.DoSomethingWithBytes();
        }
        Console.ReadKey();
    }
    internal sealed class LinesReader
    {
        private static readonly byte[] EnableCode = new byte[] { 0x55, 0x92, 4, 0x15 };
        private static readonly byte[] DisableCode = new byte[] { 0x55, 0x91, 4, 0x16 };
        private readonly SerialPort sp;
        private readonly List<LineInput> lines = new List<LineInput>();
        public LinesReader()
        {
            sp = new SerialPort("COM12", 9600, Parity.None, 8, StopBits.One);
            lines.Add(new LineInput());
        }
        public void Start()
        {
            sp.DataReceived += DataReceived;
            sp.Open();
            // Start telemetry
            sp.Write(EnableCode, 0, EnableCode.Length);
        }
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            LineInput current;
            byte[] buf = new byte[sp.BytesToRead];
            sp.Read(buf, 0, buf.Length);
            for (int offset = 0; offset < buf.Length; )
            {
                current = GetCurrentLine();
                offset = current.AddBytes(offset, buf);
            }
        }
        private LineInput GetCurrentLine()
        {
            if (lines.Count == 0 || lines[lines.Count - 1].IsComplete)
            {
                var ret = new LineInput();
                lines.Add(ret);
                Console.WriteLine($"Starting line {lines.Count}");
                return ret;
            }
            return lines[lines.Count - 1];
        }
        public IEnumerable<LineInput> ValidLines => lines.Where(e => e.IsValid);
        public void Stop()
        {
            // Stop telemetry
            sp.Write(DisableCode, 0, DisableCode.Length);
            sp.DataReceived -= DataReceived;
            sp.Close();
        }
    }
    internal sealed class LineInput
    {
        private readonly List<byte> bytesInLine = new List<byte>();
        public static byte StartCode { get; } = 0x55;
        public bool IsComplete { get; private set; }
        public void DoSomethingWithBytes()
        {
            //Here I'm just printing the line.
            Console.WriteLine(bytesInLine);
        }
        public bool IsValid
        {
            get
            {
                if (!IsComplete) return false;
                //TODO - checksum (return true if checksum correct)
                return true;
            }
        }
        /// <summary>
        /// Adds bytes until the end of the array or a 0x55 code is read
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>The new offset to start the next segment at.</returns>
        public int AddBytes(int offset, byte[] bytes)
        {
            int bytePosition = offset;
            while (bytePosition < bytes.Length)
            {
                var currentByte = bytes[bytePosition];
                if (currentByte == StartCode)
                {
                    IsComplete = true;
                    break;
                }
                bytesInLine.Add(currentByte);
                bytePosition++;
            }
            return bytePosition;
        }
    }
