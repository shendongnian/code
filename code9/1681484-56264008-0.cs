csharp
public static class Docker
{
    static Docker()
    {
        DefaultLocalApiUri = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) 
            ? new Uri("npipe://./pipe/docker_engine")
            : new Uri("unix:/var/run/docker.sock");
    }
    
    public static Uri DefaultLocalApiUri { get; }
}
