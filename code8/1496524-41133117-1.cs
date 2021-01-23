    [Guid("C8B306A5-980D-4226-8130-5E2E0F710FC2")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface comInterface
    {
        [DispId(1)]
        Task firstTask();
    }
