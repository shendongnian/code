                GCHandle gch = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                try
                {
                    r = WdfWin32Native.ReadFile(handle, bytes, count, out numBytesRead, IntPtr.Zero);
                }
                finally
                {
                    gch.Free();
                }
