     using NAudio.Utils;
     using NAudio.Wave;
     using System;
     using System.Collections.Generic;
     using System.IO;
     using System.Linq;
     using System.Text;
     using System.Threading;
     using System.Threading.Tasks;
     namespace ConsoleApp2
     {
    class Program
    {
        private static List<WaveInCapabilities> sources = new List<WaveInCapabilities>();
        private static List<string> Devices = new List<string>();
        private static List<string> Channels = new List<string>();
        static WaveInEvent source;
        static WaveOut _waveOut;
        static WaveFileWriter writer;
        static Stream memoryStream;
        static WaveFormat _waveFormat;
        static void Main(string[] args)
        {
            if (memoryStream == null)
                memoryStream = new MemoryStream();
            GetMicDevices();
            StartMic();
        }
        
        /// <summary>
        /// get all the devices that can record audio
        /// </summary>
        public static void GetMicDevices()
        {
            //get the capabilities of all the devices
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                sources.Add(WaveIn.GetCapabilities(i));
            }
            foreach (var i in sources)
            {
                Devices.Add(i.ProductName);
                Channels.Add(i.Channels.ToString());
            }
        }
       
        public static void StartMic()
        {
            //set the device number
            int DeviceNum = 0;
            source = new WaveInEvent();
            source.DataAvailable += Source_DataAvailable;
            source.RecordingStopped += Source_RecordingStopped;
            //set the device number
            source.DeviceNumber = DeviceNum;
            //create the waveFormat                        num of channels for the device
            _waveFormat= new WaveFormat(44100, WaveIn.GetCapabilities(DeviceNum).Channels);
            source.WaveFormat = _waveFormat;
            writer = new WaveFileWriter(new IgnoreDisposeStream(memoryStream), _waveFormat);
            //start the mic
            Console.WriteLine("Start Rec");
            source.StartRecording();
            //record for 3 seconds
            Thread.Sleep(3000);
            //stop the mic
            source.StopRecording();
            Console.WriteLine("End Rec");
            //play test
            Console.WriteLine("Play test");
            //play the sound from the byte array
            IWaveProvider provider = new RawSourceWaveStream(
                         memoryStream, _waveFormat);
            _waveOut = new WaveOut();
            _waveOut.Init(provider);
            _waveOut.Play();
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
        private static void Source_RecordingStopped(object sender, StoppedEventArgs e)
        {
            source.Dispose();
            source = null;
            if (writer != null)
            {
                writer.Close();
               writer = null;
            }
        }
        private static void Source_DataAvailable(object sender, WaveInEventArgs e)
        {   //convert the sound into a byte array
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }
       
    }
     }
