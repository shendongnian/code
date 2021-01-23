    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using RGiesecke.DllExport;
    using System.IO;
    
    namespace Com_1
    {
    
        [Guid("F35D5D5D-4A3C-4042-AC35-CE0C57AF8383")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComVisible(true)]
        public interface IComClass1
        {
            void SetAppDomainData(string data);
            string GetAppDomainData();
            int GetAppDomainHash();
        }
    
        //https://gist.github.com/jjeffery/1568627
        [Guid("00000001-0000-0000-c000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        internal interface IClassFactory
        {
            void CreateInstance([MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObject);
            void LockServer(bool fLock);
        }
    
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("3CA12D49-CFE5-45A3-B114-22DF2D7A0CAB")]
        [Description("Sample COM Class 1")]
        [ProgId("Com1.ComClass1")]
        public class ComClass1 : MarshalByRefObject, IComClass1, IClassFactory
        {
            public void SetAppDomainData(string data)
            {
                AppDomain.CurrentDomain.SetData("CurrentDomainCustomData", data);
            }
    
            public string GetAppDomainData()
            {
                return (string)AppDomain.CurrentDomain.GetData("CurrentDomainCustomData");
            }
    
            public int GetAppDomainHash()
            {
                return AppDomain.CurrentDomain.GetHashCode();
            }
    
            [DllExport]
            public static uint DllGetClassObject(Guid rclsid, Guid riid, out IntPtr ppv)
            {
                ppv = IntPtr.Zero;
    
                try
                {
                    if (riid.CompareTo(Guid.Parse("00000001-0000-0000-c000-000000000046")) == 0)
                    {
                        //Call to DllClassObject is requesting IClassFactory.
                        var instance = new ComClass1();
                        IntPtr iUnk = Marshal.GetIUnknownForObject(instance);
                        //return instance;
                        Marshal.QueryInterface(iUnk, ref riid, out ppv);
                        return 0;
                    }
                    else
                        return 0x80040111; //CLASS_E_CLASSNOTAVAILABLE
                }
                catch
                {
                    return 0x80040111; //CLASS_E_CLASSNOTAVAILABLE
                }        
            }
    
            public void CreateInstance([MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObject)
            {
                IntPtr ppv = IntPtr.Zero;
    
                //http://stackoverflow.com/a/13355702/864414
                AppDomainSetup domaininfo = new AppDomainSetup();
                domaininfo.ApplicationBase = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
                var curDomEvidence = AppDomain.CurrentDomain.Evidence;
                AppDomain newDomain = AppDomain.CreateDomain("MyDomain", curDomEvidence, domaininfo);
    
                Type type = typeof(ComClass1);
                var instance = newDomain.CreateInstanceAndUnwrap(
                       type.Assembly.FullName,
                       type.FullName);
    
                ppvObject = instance;
            }
    
            public void LockServer(bool fLock)
            {
                //Do nothing
            }
        }
    }
