    using System;
    using System.Runtime.InteropServices;
    
    namespace ManagedColorPlayground
    {
        using static NativeMethods;
    
        class Program
        {
            static void Main(string[] args)
            {
                float redScale = 0.2126f, greenScale = 0.7152f, blueScale = 0.0722f;
                var magEffectInvert = new MAGCOLOREFFECT {
                    transform = new [] {
                        redScale,   redScale,   redScale,   0.0f,  0.0f,
                        greenScale, greenScale, greenScale, 0.0f,  0.0f,
                        blueScale,  blueScale,  blueScale,  0.0f,  0.0f,
                        0.0f,       0.0f,       0.0f,       1.0f,  0.0f,
                        0.0f,       0.0f,       0.0f,       0.0f,  1.0f
                    }
                };
    
                MagInitialize();
                MagSetFullscreenColorEffect(ref magEffectInvert);
                Console.ReadLine();
                MagUninitialize();
            }
        }
    
        static class NativeMethods
        {
            const string Magnification = "Magnification.dll";
    
            [DllImport(Magnification, ExactSpelling = true, SetLastError = true)]
            public static extern bool MagInitialize();
    
            [DllImport(Magnification, ExactSpelling = true, SetLastError = true)]
            public static extern bool MagUninitialize();
    
            [DllImport(Magnification, ExactSpelling = true, SetLastError = true)]
            public static extern bool MagSetFullscreenColorEffect(ref MAGCOLOREFFECT pEffect);
    
            public struct MAGCOLOREFFECT
            {
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
                public float[] transform;
            }
        }
    }
