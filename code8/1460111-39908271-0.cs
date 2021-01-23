    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    public static class DLL
    {
        [DllImport("librtcmix_embedded")]
        public static extern int RTcmix_runAudio(IntPtr k, IntPtr outAudioBuffer, int nframes);
    }
    public class MyTest
    {
        void OnAudioFilterRead(out float[] data, int channels)
            {
                int[] destination = new int[channels];
                IntPtr buffer = Marshal.AllocHGlobal(4*channels);
    
                DLL.RTcmix_runAudio((IntPtr)0, buffer, channels);            
    
                Marshal.Copy(buffer, destination, 0, channels);
    
                Marshal.FreeHGlobal(buffer);
    
                data = destination.Select(item => (float)item).ToArray();
    
            }
    }
