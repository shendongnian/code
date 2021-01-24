    using System;
    using System.IO.Ports;
    using System.Windows.Forms;
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            private readonly SerialData _data;
            public Form1()
            {
                InitializeComponent();
                Closing += (sender, args) => { _data.Dispose(); };
                _data = new SerialData(new SerialPort("COM5", 9600));
                _data.DataReceived += Serial_DataReceived;
            }
            private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                // do something
            }
        }
        public class SerialData : IDisposable
        {
            private readonly object _locker = new object();
            private readonly SerialPort _port;
            public SerialData(SerialPort port)
            {
                _port = port ?? throw new ArgumentNullException(nameof(port));
            }
            #region IDisposable Members
            public void Dispose()
            {
                _port.Dispose();
            }
            #endregion
            public event SerialDataReceivedEventHandler DataReceived
            {
                add
                {
                    lock (_locker)
                    {
                        _port.DataReceived += value;
                    }
                }
                remove
                {
                    lock (_locker)
                    {
                        _port.DataReceived -= value;
                    }
                }
            }
        }
    }
