        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static unsafe extern Object _CreateCaObject(RuntimeModule pModule, IRuntimeMethodInfo pCtor, byte** ppBlob, byte* pEndBlob, int* pcNamedArgs);
        [System.Security.SecurityCritical]  // auto-generated
        private static unsafe Object CreateCaObject(RuntimeModule module, IRuntimeMethodInfo ctor, ref IntPtr blob, IntPtr blobEnd, out int namedArgs)
        {
            byte* pBlob = (byte*)blob;
            byte* pBlobEnd = (byte*)blobEnd;
            int cNamedArgs; 
            object ca = _CreateCaObject(module, ctor, &pBlob, pBlobEnd, &cNamedArgs);
            blob = (IntPtr)pBlob;
            namedArgs = cNamedArgs;
            return ca;
        }
