    using System;
    using System.IO.Ports;
    using System.Linq;
    using System.Threading;
    public class SPHandler
    {
        /// <summary>
        /// Your serial port
        /// </summary>
        private SerialPort _serialPort;
        private int _timeOut, _timeOutDefault;
        private AutoResetEvent _receiveNow;
        /// <summary>
        /// Possible device end responses such as \r\nOK\r\n, \r\nERROR\r\n, etc.
        /// </summary>
        private string[] _endResponses;
        public SPHandler()
        {
        }
        public void SetPort(string portName, int baudRate, int timeOut, string[] endResponses = null)
        {
            _timeOut = timeOut;
            _timeOutDefault = timeOut;
            _serialPort = new SerialPort(portName, baudRate);
            _serialPort.Parity = Parity.None;
            _serialPort.Handshake = Handshake.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.RtsEnable = true;
            _serialPort.DtrEnable = true;
            _serialPort.WriteTimeout = _timeOut;
            _serialPort.ReadTimeout = _timeOut;
            if (endResponses == null)
                _endResponses = new string[0];
            else
                _endResponses = endResponses;
        }
        public bool Open()
        {
            try
            {
                if (_serialPort != null && !_serialPort.IsOpen)
                {
                    _receiveNow = new System.Threading.AutoResetEvent(false);
                    _serialPort.Open();
                    _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                {
                    _receiveNow.Set();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Close()
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public string ExecuteCommand(string cmd)
        {
            _serialPort.DiscardOutBuffer();
            _serialPort.DiscardInBuffer();
            _receiveNow.Reset();
            _serialPort.Write(cmd); // Sometimes  + "\r" is needed. Depends on the device
            
            string input = ReadResponse(); // Returns device response whenever you execute a command
            _timeOut = _timeOutDefault;
            return input;
        }
        private string ReadResponse()
        {
            string buffer = string.Empty;
            try
            {
                do
                {
                    if (_receiveNow.WaitOne(_timeOut, false))
                    {
                        string t = _serialPort.ReadExisting();
                        buffer += t;
                    }
                } while (!_endResponses.Any(r => buffer.EndsWith(r, StringComparison.OrdinalIgnoreCase))); // Read while end responses are not yet received
            }
            catch
            {
                buffer = string.Empty;
            }
            return buffer;
        }
    }
