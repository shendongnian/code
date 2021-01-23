    internal static async Task CleanupComObjects(params object[] toRelease)
    {
        await Task.WhenAll(toRelease.Select((x) => 
            Task.Run(() => 
            System.Runtime.InteropServices.Marshal.ReleaseComObject(x))));
        System.GC.Collect();
    }
