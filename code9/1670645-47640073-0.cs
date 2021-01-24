    using System;
    using System.IO;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Runtime.CompilerServices;
    
    namespace EmIm
    {
        public static class Bck
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            public static Image GetBck()
            {
                Bitmap bmp = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("a.png"));
                Image rtn = bmp;
                return rtn;
            }
        }
    }
