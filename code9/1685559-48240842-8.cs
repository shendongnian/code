    /// <summary>
    /// Deletes an existing printer port from the printer management
    /// </summary>
    /// <param name="configurationType">The configuration type of the port. For example Standard TCP/IP Port.</param>
    /// <param name="portName"></param>
    public static void DeletePrinterPort(string configurationType, string portName)
    {
        // Validation
        if (String.IsNullOrEmpty(configurationType))
            throw new ArgumentNullException(nameof(configurationType));
        if (String.IsNullOrEmpty(portName))
            throw new ArgumentNullException(nameof(portName));
        // Opens the printer management
        PrinterDefaults defaults = new PrinterDefaults { DesiredAccess = PrinterAccess.ServerAdmin };
        if (!OpenPrinter(",XcvMonitor " + configurationType, out IntPtr printerHandle, ref defaults))
        {
            string message = String.Format(Resources.FailedToOpenPrinterManagement, configurationType);
            throw new PrinterManagementHelperException(message);
        }
        try
        {
            // Defines the port properties
            DeletePort portData = new DeletePort
            {
                dwVersion = 1,
                dwReserved = 0,
                sztPortName = portName
            };
            // Sets the port properties into the pointer
            uint size = (uint)Marshal.SizeOf(portData);
            IntPtr pointer = Marshal.AllocHGlobal((int)size);
            Marshal.StructureToPtr(portData, pointer, true);
            try
            {
                // Deletes the port from the printer management
                if (!XcvDataW(printerHandle, "DeletePort", pointer, size, out IntPtr outputData, 0, out uint outputNeeded, out uint status))
                    throw new PrinterManagementHelperException(Resources.FailedToDeletePrinterPortFromPrinterManagement);
            }
            catch (Exception exception)
            {
                Marshal.FreeHGlobal(pointer);
                throw new PrinterManagementHelperException(Resources.FailedToDeletePrinterPortFromPrinterManagement, exception);
            }
        }
        catch (Exception exception)
        {
            string message = string.Format(Resources.FailedToDeletePrinterPort, configurationType, portName);
            throw new PrinterManagementHelperException(message, exception);
        }
        finally
        {
            ClosePrinter(printerHandle);
        }
    }
