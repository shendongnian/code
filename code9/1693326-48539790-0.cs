    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    
    internal struct PropertyKey
    {
      Guid formatId;
      int propertyId;
    
      internal PropertyKey(Guid guid, int propertyId)
      {
          this.formatId = guid;
          this.propertyId = propertyId;
      }
    }
    
    [StructLayout(LayoutKind.Explicit)]
    internal struct PropVariant
    {
      [FieldOffset(0)] internal ushort vt;
      [FieldOffset(8)] internal IntPtr pv;
      [FieldOffset(8)] internal UInt64 padding;
    
      [DllImport("Ole32.dll", PreserveSig = false)]
      internal static extern void PropVariantClear(ref PropVariant pvar);
    
      internal PropVariant(string value)
      {
          this.vt = (ushort)VarEnum.VT_LPWSTR;
          this.padding = 0;
          this.pv = Marshal.StringToCoTaskMemUni(value);
      }
    
      internal void Clear()
      {
        PropVariantClear (ref this);
      }
    }
    
    [ComImport,
    Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IPropertyStore
    {
      int GetCount([Out] out uint propertyCount);
      void GetAt([In] uint propertyIndex, [Out, MarshalAs(UnmanagedType.Struct)] out PropertyKey key);
      void GetValue([In, MarshalAs(UnmanagedType.Struct)] ref PropertyKey key, [Out, MarshalAs(UnmanagedType.Struct)] out PropVariant pv);
      void SetValue([In, MarshalAs(UnmanagedType.Struct)] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Struct)] ref PropVariant pv);
      void Commit();
    }
    
    internal static class TaskBar {
      [DllImport("shell32.dll")]
      static extern int SHGetPropertyStoreForWindow(
          IntPtr hwnd,
          ref Guid iid /*IID_IPropertyStore*/,
          [Out(), MarshalAs(UnmanagedType.Interface)]out IPropertyStore propertyStore);
    
      internal static class Key {
        private static Guid propGuid = new Guid("9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3");
        internal static PropertyKey AppId = new PropertyKey(propGuid, 5);
        internal static PropertyKey RelaunchCommand = new PropertyKey(propGuid, 2);
        internal static PropertyKey DisplayName = new PropertyKey(propGuid, 4);
      }
    
      private static void ClearValue(IPropertyStore store, PropertyKey key) {
          var prop = new PropVariant();
          prop.vt = (ushort)VarEnum.VT_EMPTY;
          store.SetValue(ref key, ref prop);
      }
    
      private static void SetValue(IPropertyStore store, PropertyKey key, string value) {
        var prop = new PropVariant(value);
        store.SetValue(ref key, ref prop);
        prop.Clear();
      }
    
      internal static IPropertyStore Store(IntPtr handle) {
        IPropertyStore store;
        var store_guid = new Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99");
        int rc = SHGetPropertyStoreForWindow(handle, ref store_guid, out store);
        if (rc != 0) throw Marshal.GetExceptionForHR(rc);
        return store;
      }
    
      internal static void SetupLauncher(Form form) {
        IntPtr handle = form.Handle;
        var store = Store(handle);
        SetValue (store, Key.AppId, "Stackoverflow.chain.process.pinning");
        form.FormClosed += delegate { Cleanup(handle); };
      } 
    
      internal static void SetupLaunchee(Form form) {
        IntPtr handle = form.Handle;
        var store = Store(handle);
        SetValue (store, Key.AppId, "Stackoverflow.chain.process.pinning");
        string exePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "launcher.exe");
        SetValue (store, Key.RelaunchCommand, exePath);
        SetValue (store, Key.DisplayName, "Test");
        form.FormClosed += delegate { Cleanup(handle); };
      }
    
      internal static void Cleanup(IntPtr handle) {
        var store = Store(handle);
        ClearValue (store, Key.AppId);
        ClearValue (store, Key.RelaunchCommand);
        ClearValue (store, Key.DisplayName);
      }
    }
