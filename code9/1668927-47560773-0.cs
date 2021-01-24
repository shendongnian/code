    #region Using Directives
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    #endregion
    
    namespace MyNamespace
    {
        public static class Program
        {
            #region Members: Static
            private static Int32 s_MutexMessage;
            private static Mutex s_Mutex;
            #endregion
    
            #region Properties: Static
            public static Int32 MutexMessage
            {
                get { return s_MutexMessage; }
            }
            #endregion
    
            #region Methods: Entry Point
            [STAThread]
            public static void Main()
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                String assemblyGuid = ((GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
                String mutexName = ("Local\\{{{0}}}").FormatInvariant(assemblyGuid);
    
                s_MutexMessage = NativeMethods.RegisterWindowMessage(assemblyGuid);
    
                Boolean mutexCreated;
                s_Mutex = new Mutex(true, mutexName, out mutexCreated);
    
                if (!mutexCreated)
                {
                    NativeMethods.PostMessage((new IntPtr(0xFFFF)), s_MutexMessage, IntPtr.Zero, IntPtr.Zero);
                    return;
                }
    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ApplicationForm());
    
                s_Mutex.ReleaseMutex();
            }
            #endregion
        }
    }
