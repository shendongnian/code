    using System.Runtime.InteropServices;
          
          var callbackHandle = default(GCHandle);
          Action<string> nativeCallback = s => {
            try {
              Debug.WriteLine("T-ID: CB - " + Thread.CurrentThread.ManagedThreadId);
              Debug.WriteLine(a.ABCD);
              tcs.SetResult(s);
            }
            finally {
              if (callbackHandle.IsAllocated) {
                callbackHandle.Free();
              }
            }
          };
          callbackHandle = GCHandle.Alloc(nativeCallback);
          TestNative(nativeCallback);
