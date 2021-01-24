    using System;
    using System.IO;
    using System.Speech.Synthesis;
    using CSCore;
    using CSCore.MediaFoundation;
    using CSCore.SoundOut;
    
    namespace WaveOutTest
    {
        class Program
        {
            static void Main()
            {
                using (var stream = new MemoryStream())
                using (var speechEngine = new SpeechSynthesizer())
                {
                    Console.WriteLine("Available devices:");
                    foreach (var device in WaveOutDevice.EnumerateDevices())
                    {
                        Console.WriteLine("{0}: {1}", device.DeviceId, device.Name);
                    }
                    Console.WriteLine("\nEnter device for speech output:");
                    var deviceId = (int)char.GetNumericValue(Console.ReadKey().KeyChar);
    
                    speechEngine.SetOutputToWaveStream(stream);
                    speechEngine.Speak("Testing 1 2 3");
    
                    using (var waveOut = new WaveOut { Device = new WaveOutDevice(deviceId) })
                    using (var waveSource = new MediaFoundationDecoder(stream))
                    {
                        waveOut.Initialize(waveSource);
                        waveOut.Play();
                        waveOut.WaitForStopped();
                    }
                }
            }
        }
    }
