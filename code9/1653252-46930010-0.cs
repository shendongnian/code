    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Linq;
    using System.Text;
    using System.Threading;
    public class SerialPortHandler
    {
        public delegate void OnReportHandler(byte[] data);
        public delegate void OnReadExceptionHander(Exception error);
        public delegate void OnHandlingExceptionHandler(Exception error);
        public SerialPortHandler(string portName, Predicate<byte[]> reportPredicate, Func<Queue<byte>, byte[]> dequeueFunc)
            : this(reportPredicate, dequeueFunc)
        {
            this._serialPort = new SerialPort(portName);
        }
        public SerialPortHandler(string portName, int baudRate, Predicate<byte[]> reportPredicate, Func<Queue<byte>, byte[]> dequeueFunc)
           : this(reportPredicate, dequeueFunc)
        {
            this._serialPort = new SerialPort(portName, baudRate);
        }
        public SerialPortHandler(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, Predicate<byte[]> reportPredicate, Func<Queue<byte>, byte[]> dequeueFunc)
          : this(reportPredicate, dequeueFunc)
        {
            this._serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
        }
        private SerialPortHandler(Predicate<byte[]> reportPredicate, Func<Queue<byte>, byte[]> dequeueFunc)
        {
            _thrdRead = new Thread(new ThreadStart(Read));
            _thrdHandle = new Thread(new ThreadStart(DataHandling));
            _isRun = false;
            _quCmdRespone = new Queue<byte[]>();
            _quReceiveBuff = new Queue<byte>();
            _cmdResponseReset = new AutoResetEvent(false);
            _reportPredicate = reportPredicate;
            _dequeueFunc = dequeueFunc;
        }
        SerialPort _serialPort;
        Thread _thrdRead;
        Thread _thrdHandle;
        bool _isRun;
        /// <summary>
        /// Save all data read from the serial port
        /// </summary>
        Queue<byte> _quReceiveBuff;
        /// <summary>
        /// Save the response of the last command
        /// </summary>
        Queue<byte[]> _quCmdRespone;
        AutoResetEvent _cmdResponseReset;
        bool _isSending;
        /// <summary>
        /// A method to determine whether a byte[] is a spontaneous report of a serial port
        /// </summary>
        Predicate<byte[]> _reportPredicate;
        /// <summary>
        /// Dequeuing a command from the received data queue method
        /// </summary>
        Func<Queue<byte>, byte[]> _dequeueFunc;
        /// <summary>
        /// Called when the serial interface is actively reporting data.
        /// </summary>
        public event OnReportHandler OnReport;
        public event OnReadExceptionHander OnReadException;
        public event OnHandlingExceptionHandler OnHandlingException;
        public bool IsOpen
        {
            get { return this._serialPort == null ? false : this._serialPort.IsOpen; }
        }
        /// <summary>
        /// Read data from serial port.
        /// </summary>
        private void Read()
        {
            while (_isRun)
            {
                try
                {
                    if (this._serialPort == null || !this._serialPort.IsOpen || this._serialPort.BytesToRead == 0)
                    {
                        SpinWait.SpinUntil(() => this._serialPort != null && this._serialPort.IsOpen && this._serialPort.BytesToRead > 0, 10);
                        continue;
                    }
                    byte[] data = new byte[this._serialPort.BytesToRead];
                    this._serialPort.Read(data, 0, data.Length);
                    Array.ForEach(data, b => _quReceiveBuff.Enqueue(b));
                }
                catch (InvalidOperationException)
                {
                    if (!_isRun || this._serialPort ==null)
                        return;
                    else
                        this._serialPort.Open();
                }
                catch (Exception ex)
                {
                    this.OnReadException?.BeginInvoke(new Exception(string.Format("An error occurred in the reading processing: {0}", ex.Message), ex), null, null);
                }
            }
        }
        /// <summary>
        /// Data processing
        /// </summary>
        private void DataHandling()
        {
            while (_isRun)
            {
                try
                {
                    if (_quReceiveBuff.Count == 0)
                    {
                        SpinWait.SpinUntil(() => _quReceiveBuff.Count > 0, 10);
                        continue;
                    }
                    byte[] data = _dequeueFunc(_quReceiveBuff);
                    if (data == null || data.Length == 0)
                    {
                        SpinWait.SpinUntil(() => false, 10);
                        continue;
                    }
                    if (_reportPredicate(data))
                        OnReport?.BeginInvoke(data, null, null);    //If the data is spontaneously reported by the serial port, the OnReport event is called
                    else
                    {                                               //If the command response returned by the serial port, join the command response queue
                        if (_quCmdRespone.Count > 0)
                            _quCmdRespone.Clear();                  //The queue is cleared to ensure that if a command timed out does not affect subsequent command results
                        _quCmdRespone.Enqueue(data);
                        _cmdResponseReset.Set();
                    }
                }
                catch (Exception ex)
                {
                    this.OnHandlingException?.BeginInvoke(new Exception(string.Format("An error occurred in the data processing: {0}", ex.Message), ex), null, null);
                }
            }
        }
        /// <summary>
        /// Read the response of the last command.
        /// </summary>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        private byte[] ReadCommandResponse(int timeOut)
        {
            byte[] buffer = null;
            if (_cmdResponseReset.WaitOne(timeOut, false))
                buffer = _quCmdRespone.Dequeue();
            return buffer;
        }
        /// <summary>
        /// Send a command
        /// </summary>
        /// <param name="sendData">command buff</param>
        /// <param name="receiveData">REF: response of command</param>
        /// <param name="timeout">timeout(millseconds)</param>
        /// <returns>count of response, -1: failure, -2: port is busy</returns>
        public int SendCommand(byte[] sendData, ref byte[] receiveData, int timeout)
        {
            if (_isSending)
                return -2;
            if (this._serialPort.IsOpen)
            {
                try
                {
                    _isSending = true;
                    this._serialPort.Write(sendData, 0, sendData.Length);
                    int ret = 0;
                    receiveData = ReadCommandResponse(timeout);
                    ret = receiveData == null ? -1 : receiveData.Length;
                    return ret;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Send command is failure：{0}", ex.Message), ex);
                }
                finally
                {
                    _isSending = false;
                }
            }
            return -1;
        }
        public bool Open()
        {
            if (this._serialPort == null || this._serialPort.IsOpen)
                return false;
            this._serialPort.Open();
            _isRun = true;
            _thrdRead.Start();
            _thrdHandle.Start();
            return true;
        }
        public bool Close()
        {
            _isRun = false;
            if (_thrdHandle.IsAlive)
                _thrdHandle.Join();
            if (_thrdRead.IsAlive)
                _thrdRead.Join();
            if (this._serialPort == null)
                return false;
            if (this._serialPort.IsOpen)
                this._serialPort.Close();
            return true;
        }
    }
