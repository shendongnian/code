    // !!! THIS CODE INVOLVES A SERIOUS HACK !!!
    // !!! USE AT YOUR OWN RISK              !!!
    [ComVisible(true)]
    [Guid(...)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IMyInterface))]
    public class MyObject : IMyInterface, IDisposable
    {
        // constructor
        public MyObject()
        {
            // get and store this object's IUnknown* (this adds a reference)
            _pUnknown = Marshal.GetIUnknownForObject(this);
            // get a pointer to the vtable from the IUnknown
            var pVTable = Marshal.ReadIntPtr(_pUnknown);
            // get a pointer to the Release method from the vtable
            var pRelease = Marshal.ReadIntPtr(pVTable, 2 * IntPtr.Size);
            // get and store a delegate to the original Release method
            _originalRelease = (ReleaseDelegate) Marshal.GetDelegateForFunctionPointer(pRelease, typeof(ReleaseDelegate));
            // set the entry for the Release method in the vtable to a pointer for the ReleaseOverride method
            var pReleaseOverride = Marshal.GetFunctionPointerForDelegate(OverriddenRelease);
            Marshal.WriteIntPtr(pVTable, 2 * IntPtr.Size, pReleaseOverride);
        }
        // this method will be called when a COM client releases
        private static int ReleaseOverride(IntPtr pUnknown)
        {
            // get the object being released
            var o = (MyObject) Marshal.GetObjectForIUnknown(pUnknown);
            // call the original release method
            var refCount = o._originalRelease(pUnknown);
            // if the remaining reference count is 1, the only
            // outstanding reference is the reference acquired through
            // the Marshal.GetIUnknownForObject call in the constructor
            if (refCount == 1)
            {
                // release the reference we acquired in the constructor
                refCount = Marshal.Release(o._pUnknown);
                // and call Dispose
                o.Dispose();
            }
            // return the ref count
            return refCount;
        }
        // this method will now be called when all COM clients release
        public void Dispose()
        {
        }
        // the IUnknown pointer for this object
        private readonly IntPtr _pUnknown;
        // a delegate to the original Release method
        private readonly ReleaseDelegate _originalRelease;
        // a delegate to the ReleaseOverride method
        private static readonly ReleaseDelegate OverriddenRelease = ReleaseOverride;
        // the Release delegate type
        private delegate int ReleaseDelegate(IntPtr pUnknown);
    }
