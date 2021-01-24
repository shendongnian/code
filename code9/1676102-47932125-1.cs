      public void RegisterDeviceNotification()
      {
          InitArrayDevNotifyHandle();
          myCallback = new Win32.ServiceControlHandlerEx(ControlHandler);
          Win32.RegisterServiceCtrlHandlerEx(service.ServiceName, myCallback, IntPtr.Zero);
          if (service.GetServiceHandle() == IntPtr.Zero)
          {
            // TODO handle error
          }
          Win32.DEV_BROADCAST_DEVICEINTERFACE deviceInterface = new Win32.DEV_BROADCAST_DEVICEINTERFACE();
          int size = Marshal.SizeOf(deviceInterface);
          deviceInterface.dbcc_size = size;
          deviceInterface.dbcc_devicetype = Win32.DBT_DEVTYP_DEVICEINTERFACE;
          IntPtr buffer = default(IntPtr);
          buffer = Marshal.AllocHGlobal(size);
          Marshal.StructureToPtr(deviceInterface, buffer, true);
          deviceEventHandle = Win32.RegisterDeviceNotification(service.GetServiceHandle(), buffer, Win32.DEVICE_NOTIFY_SERVICE_HANDLE | Win32.DEVICE_NOTIFY_ALL_INTERFACE_CLASSES);
        
          if (deviceEventHandle == IntPtr.Zero)
          {
            // TODO handle error
          }
      }
