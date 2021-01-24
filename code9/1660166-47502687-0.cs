    [ComImport, Guid("228826af-02e1-4226-a9e0-99a855e455a6")]
    class ImmersiveShellBroker
    {
    }
    [ComImport, Guid("9767060c-9476-42e2-8f7b-2f10fd13765c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IImmersiveShellBroker
    {
        void Dummy();
        IInputHostManagerBroker GetInputHostManagerBroker();
    }
    [ComImport, Guid("2166ee67-71df-4476-8394-0ced2ed05274")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IInputHostManagerBroker
    {
        void GetIhmLocation(out Rect rect, out DisplayMode mode);
    }
    [StructLayout(LayoutKind.Sequential)]
    struct Rect
    {
        public int Left, Top, Right, Bottom;
    }
    enum DisplayMode
    {
        NotSupported = 0,
        Floating = 2,
        Docked = 3,
    }
