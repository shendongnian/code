             try
             {
                AutoResetEvent _eventNotify = new AutoResetEvent(false);
                WaitHandle[] waitHandles = new WaitHandle[] 
                {_eventNotify,    eventTerminate };
                while (!eventTerminate.WaitOne(0, true))
                {
                    result = RegNotifyChangeKeyValue(registryKey, false, regFilter, _eventNotify.SafeWaitHandle, true);
                    if (WaitHandle.WaitAny(waitHandles) == 0)
                    {
                        retVal = RegQueryValueEx(registryKey, registryValueName, 0, ref type, pResult, ref size);
                        if (retVal == 0)
                        {
                            string currentValue = Marshal.PtrToStringAnsi(pResult);
                            if(!cachedValue.Equals(currentValue,StringComparison.InvariantCultureIgnoreCase))
                            {
                                OnRegistryChanged();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (registryKey != IntPtr.Zero)
                {
                    RegCloseKey(registryKey);
                }
            }
