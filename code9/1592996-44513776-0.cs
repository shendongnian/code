    [ComVisible(true)]
    public class Class1 : ICustomQueryInterface, IMyUnknown
    {
        CustomQueryInterfaceResult ICustomQueryInterface.GetInterface(ref Guid iid, out IntPtr ppv)
        {
            if (iid == typeof(IMyUnknown).GUID)
            {
                ppv = Marshal.GetComInterfaceForObject(this, typeof(IMyUnknown), CustomQueryInterfaceMode.Ignore);
                return CustomQueryInterfaceResult.Handled;
            }
            ppv = IntPtr.Zero;
            return CustomQueryInterfaceResult.NotHandled;
        }
        // an automatic IDispatch method
        public void MyDispatchMethod()
        {
           ...
        }
        // the IMyUnknown method
        // note you can declare that method with a private implementation
        public void MyUnknownMethod()
        {
           ...
        }
    }
