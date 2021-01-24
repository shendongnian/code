    UnityThread.executeInUpdate(() =>
    {
        if (stream != null)
        {
            tex.LoadImage(stream.ToArray());
    
            renderer.material.mainTexture = tex;
            stream.Dispose();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }
    });
