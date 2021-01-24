    [...]
    library ProcessorLibrary
    {
        importlib("FaceLibrary.tlb");
        [...]
        interface IProcessor
        {
            HRESULT ProcessFace(FaceLibrary.IFace* face)
        };
    }
