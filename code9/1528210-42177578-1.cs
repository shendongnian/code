    using System.Runtime.InteropServices;
    class MySynchronizationContext : SynchronizationContext {
        public MySynchronizationContext() {
            base.SetWaitNotificationRequired();
        }
        public override int Wait(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout) {
            return WaitForMultipleObjects(waitHandles.Length, waitHandles, false, millisecondsTimeout);
        }
        [DllImport("kernel32.dll")]
        static extern int WaitForMultipleObjects(int nCount, IntPtr[] lpHandles,
            bool bWaitAll, int dwMilliseconds);
    }
