    using System;
    using NAudio.Wave;
    using NAudio.Wave.SampleProviders;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                ISampleProvider provider1 = new SignalGenerator
                {
                    Frequency = 1000.0f,
                    Gain = 0.5f
                };
    
                ISampleProvider provider2 = new SignalGenerator
                {
                    Frequency = 1250.0f,
                    Gain = 0.5f
                };
    
                var takeDuration1 = TimeSpan.FromSeconds(5); // otherwise it would emit indefinitely
                var takeDuration2 = TimeSpan.FromSeconds(10);
    
                var sources = new[]
                {
                    provider1.Take(takeDuration1),
                    provider2.Take(takeDuration2)
                };
    
                var mixingSampleProvider = new MixingSampleProvider(sources);
    
                var waveProvider = mixingSampleProvider.ToWaveProvider();
    
                WaveFileWriter.CreateWaveFile("test.wav", waveProvider);
            }
        }
    }
