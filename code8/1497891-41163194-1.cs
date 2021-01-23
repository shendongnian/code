    [ComVisible(true)]
    [Guid("2BF7DA6B-DDB3-42A5-BD65-92EE93ABB473")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IDemoEvents
    {
        [DispId(1)]
        Task DownloadFileAsync(string address, string filename);
    }
