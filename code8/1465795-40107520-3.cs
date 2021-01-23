    using System;
    using System.Runtime.InteropServices;
    using UnityEngine;
    
    public class MyAPI : MonoBehaviour
    {
    #if UNITY_EDITOR || UNITY_STANDALONE
        const string dllname = "MyPlugin";
    #elif UNITY_IOS
        const string dllname = "__Internal";
    #endif
    
        [DllImport(dllname, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateContext();
    
        [DllImport(dllname, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetVersion(IntPtr _pContext);
    
        [DllImport(dllname, CallingConvention = CallingConvention.Cdecl)]
        private static extern void DestroyContext(IntPtr _pContext);
    
        static MyAPI()
        {
            Debug.Log("Plugin name: " + dllname);
        }
    
        void Start ()
        {
            var context = CreateContext();
            var version = GetVersion(context);
            Debug.LogFormat("Version: {0}", version);
            DestroyContext(context);
        }
    }
