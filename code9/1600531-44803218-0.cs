    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Text;
    namespace SimpleSmartCardTester
    {
        static class Program
        {
            public static class SmartCardScope
            {
                public static readonly Int32 User = 0;
                public static readonly Int32 Terminal = 1;
                public static readonly Int32 System = 2;
            }
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public struct SmartCardReaderState
            {
                public string cardReaderString;
                public IntPtr userDataPointer;
                public UInt32 currentState;
                public UInt32 eventState;
                public UInt32 atrLength;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
                public byte[] ATR;
            }
            public static class SmartCardState
            {
                public static readonly UInt32 Unaware = 0x00000000;
                public static readonly UInt32 Ignore = 0x00000001;
                public static readonly UInt32 Changed = 0x00000002;
                public static readonly UInt32 Unknown = 0x00000004;
                public static readonly UInt32 Unavailable = 0x00000008;
                public static readonly UInt32 Empty = 0x00000010;
                public static readonly UInt32 Present = 0x00000020;
                public static readonly UInt32 Atrmatch = 0x00000040;
                public static readonly UInt32 Exclusive = 0x00000080;
                public static readonly UInt32 Inuse = 0x00000100;
                public static readonly UInt32 Mute = 0x00000200;
                public static readonly UInt32 Unpowered = 0x00000400;
            }
            public const int SCARD_S_SUCCESS = 0;
            [DllImport("winscard.dll")]
            internal static extern int SCardEstablishContext(Int32 dwScope, IntPtr pReserved1, IntPtr pReserved2, out Int32 hContext);
            [DllImport("winscard.dll", EntryPoint = "SCardListReadersA", CharSet = CharSet.Ansi)]
            internal static extern int SCardListReaders(Int32 hContext, byte[] cardReaderGroups, byte[] readersBuffer, out UInt32 readersBufferLength);
            [DllImport("winscard.dll")]
            internal static extern int SCardGetStatusChange(Int32 hContext, UInt32 timeoutMilliseconds, [In, Out] SmartCardReaderState[] readerStates, Int32 readerCount);
            private static List<string> ParseReaderBuffer(byte[] buffer)
            {
                var str = Encoding.ASCII.GetString(buffer);
                if (string.IsNullOrEmpty(str)) return new List<string>();
                return new List<string>(str.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries));
            }
            private static bool CheckIfFlagsSet(UInt32 mask, params UInt32[] flagList)
            {
                foreach (UInt32 flag in flagList)
                {
                    if (IsFlagSet(mask, flag)) return true;
                }
                return false;
            }
            private static bool IsFlagSet(UInt32 mask, UInt32 flag)
            {
                return ((flag & mask) > 0);
            }
            static void Main()
            {
                int context = 0;
                Console.WriteLine("Checking card readers...)");
                var result = SCardEstablishContext(SmartCardScope.User, IntPtr.Zero, IntPtr.Zero, out context);
                if (result != SCARD_S_SUCCESS) throw new Exception("Smart card error: " + result.ToString());
                uint bufferLength = 10000;
                byte[] readerBuffer = new byte[bufferLength];
                result = SCardListReaders(context, null, readerBuffer, out bufferLength);
                if (result != SCARD_S_SUCCESS) throw new Exception("Smart card error: " + result.ToString());
                var readers = ParseReaderBuffer(readerBuffer);
                
                Console.WriteLine("{0} Card Reader(s)", readers.Count);
                if (readers.Any())
                {
                    var readerStates = readers.Select(cardReaderName => new SmartCardReaderState() { cardReaderString = cardReaderName }).ToArray();
                    result = SCardGetStatusChange(context, 1000, readerStates, readerStates.Length);
                    if (result != SCARD_S_SUCCESS) throw new Exception("Smart card error: " + result.ToString());
                    readerStates.ToList().ForEach(readerState => Console.WriteLine("Reader: {0}, State: {1}", readerState.cardReaderString,
                        CheckIfFlagsSet(readerState.eventState, SmartCardState.Present, SmartCardState.Atrmatch) ? "Card Present" : "Card Absent"));
                }
                Console.ReadLine();
            }
        }
    }
