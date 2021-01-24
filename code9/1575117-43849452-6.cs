    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO.Ports;
    using System.IO;
    using System.Threading;
    //using Sniffer_Data_Logger.Properties;
    using System.Text.RegularExpressions;
    using System.Timers;
    using System.Globalization;
    using System.Linq;
    namespace Sniffer_Data_Logger
    {
        public enum LogMsgType { Normal, Incoming, Error };
        public partial class FrmTerminal : Form
        {
            // Declare buffer & newline character for each string (09.05)
            const Boolean test = true;
            const int BUFFER_SIZE = 20480;
            const string COLON = ":";
            const byte FRAME_BYTE = 0x3A;
            private SerialPort ComPort = new SerialPort("COM3", 5250000, Parity.None, 8, StopBits.One);    // Declare new COM Port & its parameters
            public FrmTerminal()
            {
                InitializeComponent();                                                                     // Initialise componenets to load the form
                ComPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                // Datareceive event handler with string
                if (test)
                {
                    this.Load += new EventHandler(FrmTerminal_Load);
                }
                else
                {
                    ComPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);             // When data received through port call event handler
                }
            }
            private void FrmTerminal_Load(object sender, EventArgs e)
            {
                Test();
            }
            //Test for the string display
            public void Test()
            {
                lbus2sniffer data = new lbus2sniffer();
                string[] inputs =
                {
                    ": AA 01 00 13 6F BA 8B 18 85 BA 8B 18 0B 01 00 81 00 0D 00 00 C5 BA B5 82 22",
                    ": AA 01 00 13 CA BA 8B 18 E2 BA 8B 18 0C 02 00 81 00 0D 00 00 00 DE 7B D6 39 1F"
                };
                //test if buffer contains return
                receiveData = "";
                foreach (string input in inputs)
                {
                    receiveData += input;
                    if (receiveData.Contains(COLON))
                    {
                        if (receiveData.Substring(1) != COLON)
                        {
                            int index = receiveData.IndexOf(COLON);
                            if (index >= 0)
                            {
                                receiveData = receiveData.Remove(0, index + 1);
                                string first = "";
                                if (receiveData.IndexOf(COLON, 0) >= 0)
                                {
                                    first = receiveData.Substring(0, receiveData.IndexOf(COLON, 0));
                                    receiveData = receiveData.Remove(0, receiveData.IndexOf(COLON, 0));
                                }
                                else
                                {
                                    first = receiveData;
                                }
                                int bytesParsed = lbus2sniffer.Parse(first);
                                if (bytesParsed < 0)
                                {
                                    receiveData = "";
                                }
                                else
                                {
                                    receiveData = receiveData.Remove(0, bytesParsed);
                                    string printString = lbus2sniffer.Print();
                                    Log(LogMsgType.Incoming, string.Format("Sniffer Logged in {0}\t{1}\n\r", DateTime.Now, printString));  // Show the user incoming data in Hex format & after each 10 second update the data coming & post it on the newline
                                }
                            }
                            else
                            {
                                receiveData = "";
                            }
                        }
                    }
                }
            }
            private void EnableControl()
            {
                if (ComPort.IsOpen) btnOpenPort.Text = "& Close Port";
                else btnOpenPort.Text = "&Open Port";
            }
            // This function is for formatting data over Rich Text Box window of the Application
            private void Log(LogMsgType msgtype, String msg)
            {
                rtfTerminal.Invoke(new EventHandler(delegate
                {
                    rtfTerminal.SelectedText = string.Empty;
                    rtfTerminal.SelectionFont = new Font(rtfTerminal.SelectionFont, FontStyle.Bold);
                    rtfTerminal.AppendText(msg);
                    rtfTerminal.ScrollToCaret();
                }));
            }
            // This function is to convert byte in to hex string
            private string ByteArrayToHexString(byte[] data)
            {
                StringBuilder sb = new StringBuilder(/*data.Length * 3*/);
                foreach (byte b in data)
                    sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' ').Replace("AA", ": AA"));
                return sb.ToString().ToUpper();
            }
            private void btnOpenPort_Click(object sender, EventArgs e)
            {
                bool error = false;
                if (ComPort.IsOpen) ComPort.Close();                                            // Close Comport if its already open
                try
                {
                    ComPort.Open();                                                             // Opent the ComPort
                }
                catch (UnauthorizedAccessException) { error = true; }
            }
            private string receiveData = "";
            private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                Thread.Sleep(1000);                                                            // Capture data after every 10 sec
                if (!ComPort.IsOpen) return;                                                    // If comport is closed do nothing
                int bytes = ComPort.BytesToRead;
                byte[] buffer = new byte[bytes];                                                // Create byte array buffer to hold incoming data
                ComPort.Read(buffer, 0, bytes);                                                 // Read all data  from the port & store it in buffer
                receiveData += Encoding.UTF8.GetString(buffer);                                 // UTF8 Encoding for incoming string
                //test if buffer contains return
                if (receiveData.Contains(COLON))
                {
                    if (receiveData.Substring(1) != COLON)
                    {
                        int index = receiveData.IndexOf(COLON);
                        if (index >= 0)
                        {
                            receiveData = receiveData.Remove(0, index + 1);
                            string first = "";
                            if (receiveData.IndexOf(COLON, 0) >= 0)
                            {
                                first = receiveData.Substring(0, receiveData.IndexOf(COLON, 0));
                                receiveData = receiveData.Remove(0, receiveData.IndexOf(COLON, 0));
                            }
                            else
                            {
                                first = receiveData;
                            }
                            int bytesParsed = lbus2sniffer.Parse(first);
                            if (bytesParsed < 0)
                            {
                                receiveData = "";
                            }
                            else
                            {
                                receiveData = receiveData.Remove(0, bytesParsed);
                                string printString = lbus2sniffer.Print();
                                Log(LogMsgType.Incoming, string.Format("Sniffer Logged in {0}\t{1}\n\r", DateTime.Now, printString));  // Show the user incoming data in Hex format & after each 10 second update the data coming & post it on the newline
                            }
                        }
                        else
                        {
                            receiveData = "";
                        }
                    }
                }
                //string[] data = { ByteArrayToHexString(buffer).Replace("AA", "\nAA") };
                //foreach (var preamble in data)
                //{
                //    int position = preamble.IndexOf("\nAA");
                //    if (position < 0)
                //        continue;
                //    Log(LogMsgType.Incoming, string.Format("Time: {0};" + " Data: {1};", DateTime.Now.ToString("HH:mm:ss"), preamble.Substring(position))/* + ByteArrayToHexString(buffer).Replace("AA", "\nAA")*/);
                //}
                // Show the user incoming data in Hex format & after each 10 second update the data coming & post it on the newline
            }
            private void btnClear_Click(object sender, EventArgs e)
            {
                rtfTerminal.Clear();                                                            // If clear button pressed, clear the reach text box 
            }
            // Save file on the folder as the form of plain text 
            private void btnsave_Click(object sender, EventArgs e)
            {
                saveFileDialog1.Filter = "txt files (*.txt)| *.txt";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName.Length > 0)
                {
                    rtfTerminal.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                DateTime now = DateTime.Now;
                //Console.WriteLine(now);
            }
            //Define receiver protocol Structure as per Protocol description mentioned in Prot.C
            public class lbus2sniffer
            {
                public static List<lbus2sniffer> cdata = new List<lbus2sniffer>();          // Make a list view of protocol in display window
                public byte preamble { get; set; }
                public byte version { get; set; }
                public byte reserved { get; set; }
                public byte cmd { get; set; }
                public List<byte> ts1 = new List<byte>();
                public List<byte> ts2 = new List<byte>();
                public int len { get; set; }
                public List<byte> data = new List<byte>();
                public byte crc { get; set; }
                enum State
                {
                    PREAMBLE,
                    VERSION,
                    RESERVED,
                    CMD,
                    TS1,
                    TS2,
                    LEN,
                    DATA,
                    CRC
                }
                public static int Parse(string input)
                {
                    Boolean valid = false;
                    Boolean firstNibble = true;
                    int index = 0;                  // Indicates number of bytes parsed
                    string nibbleStr = "";
                    byte nibble = 0;
                    int ts1Count = 0;
                    int ts2Count = 0;
                    int dataCount = 0;
                    lbus2sniffer newData = new lbus2sniffer();
                    State state = State.PREAMBLE;
                    for (index = 0; index < input.Length; index++)
                    {
                        if ((input[index] == ' ') || (input[index] == ':'))
                        {
                            firstNibble = true;
                        }
                        else
                        {
                            if (firstNibble)
                            {
                                nibbleStr = input.Substring(index, 1);
                                firstNibble = false;
                            }
                            else
                            {
                                nibbleStr += input.Substring(index, 1);
                                if (!byte.TryParse(nibbleStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out nibble))
                                {
                                    break;
                                }
                                firstNibble = true;
                                switch (state)
                                {
                                    case State.PREAMBLE:
                                        newData.preamble = nibble;
                                        state = State.VERSION;
                                        break;
                                    case State.VERSION:
                                        newData.version = nibble;
                                        state = State.RESERVED;
                                        break;
                                    case State.RESERVED:
                                        newData.reserved = nibble;
                                        state = State.CMD;
                                        break;
                                    case State.CMD:
                                        newData.cmd = nibble;
                                        state = State.TS1;
                                        break;
                                    case State.TS1:
                                        newData.ts1.Add(nibble);
                                        if (++ts1Count == 4)
                                        {
                                            state = State.TS2;
                                        }
                                        break;
                                    case State.TS2:
                                        newData.ts2.Add(nibble);
                                        if (++ts2Count == 4)
                                        {
                                            state = State.LEN;
                                        }
                                        break;
                                    case State.LEN:
                                        newData.len = nibble;
                                        state = State.DATA;
                                        break;
                                    case State.DATA:
                                        newData.data.Add(nibble);
                                        if (++dataCount == newData.len)
                                        {
                                            state = State.CRC;
                                        }
                                        break;
                                    case State.CRC:
                                        newData.crc = nibble;
                                        cdata.Add(newData);
                                        valid = true;
                                        break;
                                }
                            }
                        }
                    }
                    if (valid)
                    {
                        return index;                                       // number of bytes parsed
                    }
                    else
                    {
                        return -1;
                    }
                }
                public static string Print()
                {
                    lbus2sniffer data = cdata.LastOrDefault();
                    string message = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}",
                        data.preamble.ToString("X2"),
                        data.version.ToString(),
                        data.reserved.ToString(),
                        data.cmd.ToString("X2"),
                        String.Join(" ", data.ts1.Select(x => x.ToString("X2"))),
                        string.Join(" ", data.ts2.Select(x => x.ToString("X2"))),
                        data.len.ToString(),
                        string.Join(" ", data.data.Select(x => x.ToString("X2"))),
                        data.crc.ToString("X2")
                        );
                    return message;
                }
            }
        }
    }
