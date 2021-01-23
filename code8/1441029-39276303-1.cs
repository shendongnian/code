    internal static Task CleanupComObjects(params object[] toRelease)
    {
        return Task.Run(() =>
        {
            foreach (object o in toRelease)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            System.GC.Collect();
        });
    }
