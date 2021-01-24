    class Program
        {
            static void Main(string[] args)
            {
                EpsonPrinter epsonPrinter = new EpsonPrinter();
                EpsonPrinterToHPPrinterAdapter adapter = new EpsonPrinterToHPPrinterAdapter(epsonPrinter);
                Printer(adapter);
                Console.ReadKey();
            }
    
    
            public static void Printer(IHPPrinter hpPrinter)
            {
                hpPrinter.PrintDocument();
            }
    
            public interface IHPPrinter
            {
                void PrintDocument();
                int DocumentsInQueue();
            }
            public interface IEpsonPrinter
            {
                void Print();
            }
    
            public class EpsonPrinterToHPPrinterAdapter :  IHPPrinter
            {
    
                public EpsonPrinterToHPPrinterAdapter(IEpsonPrinter epsonPrinter)
                {
                    EpsonPrinter = epsonPrinter;
                    _queueCount = 0;
                }
    
                private int _queueCount;
    
                public IEpsonPrinter EpsonPrinter { get; }
    
                public void PrintDocument()
                {
                    _queueCount++;
                    EpsonPrinter.Print();
                    _queueCount--;
                }
    
                public int DocumentsInQueue()
                {
                    return _queueCount;
                }
            }
    
            public class EpsonPrinter : IEpsonPrinter
            {
                public void Print()
                {
                    Console.WriteLine("Printing from Epson printer...");
                }
            }
        }
