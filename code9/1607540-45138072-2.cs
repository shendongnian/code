    using System.Runtime.InteropServices;
    using System;
    
    
    namespace STACK.OVERFLOW
    {
        public class Duplexprint
        {
    
            #region Win32 API Declaration
    
    
            [DllImport("kernel32.dll", EntryPoint = "GetLastError", SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern Int32 GetLastError();
    
    
            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);
    
    
            [DllImport("winspool.Drv", EntryPoint = "DocumentPropertiesA", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern int DocumentProperties(IntPtr hwnd, IntPtr hPrinter, [MarshalAs(UnmanagedType.LPStr)]
                string pDeviceNameg, IntPtr pDevModeOutput, IntPtr pDevModeInput, int fMode);
    
    
            [DllImport("winspool.Drv", EntryPoint = "GetPrinterA", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool GetPrinter(IntPtr hPrinter, Int32 dwLevel, IntPtr pPrinter, Int32 dwBuf, ref Int32 dwNeeded);
    
    
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            static extern int OpenPrinter(string pPrinterName, out IntPtr phPrinter, ref PRINTER_DEFAULTS pDefault);
    
    
            [DllImport("winspool.Drv", EntryPoint = "SetPrinterA", ExactSpelling = true, SetLastError = true)]
            public static extern bool SetPrinter(IntPtr hPrinter, int Level, IntPtr pPrinter, int Command);
    
    
            [StructLayout(LayoutKind.Sequential)]
            public struct PRINTER_DEFAULTS
            {
                public IntPtr pDatatype;
                public IntPtr pDevMode;
                public int DesiredAccess;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct PRINTER_INFO_9
            {
    
                public IntPtr pDevMode;
                // Pointer to SECURITY_DESCRIPTOR
                public int pSecurityDescriptor;
            }
    
            public const short CCDEVICENAME = 32;
    
            public const short CCFORMNAME = 32;
    
            [StructLayout(LayoutKind.Sequential)]
            public struct DEVMODE
            {
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCDEVICENAME)]
                public string dmDeviceName;
                public short dmSpecVersion;
                public short dmDriverVersion;
                public short dmSize;
                public short dmDriverExtra;
                public int dmFields;
                public short dmOrientation;
                public short dmPaperSize;
                public short dmPaperLength;
                public short dmPaperWidth;
                public short dmScale;
                public short dmCopies;
                public short dmDefaultSource;
                public short dmPrintQuality;
                public short dmColor;
                public short dmDuplex;
                public short dmYResolution;
                public short dmTTOption;
                public short dmCollate;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCFORMNAME)]
                public string dmFormName;
                public short dmUnusedPadding;
                public short dmBitsPerPel;
                public int dmPelsWidth;
                public int dmPelsHeight;
                public int dmDisplayFlags;
                public int dmDisplayFrequency;
            }
    
    
            public const Int64 DM_DUPLEX = 0x1000L;
            public const Int64 DM_ORIENTATION = 0x1L;
            public const Int64 DM_SCALE = 0x10L;
            public const Int64 DMORIENT_PORTRAIT = 0x1L;
            public const Int64 DMORIENT_LANDSCAPE = 0x2L;
            public const Int32 DM_MODIFY = 8;
            public const Int32 DM_COPY = 2;
            public const Int32 DM_IN_BUFFER = 8;
            public const Int32 DM_OUT_BUFFER = 2;
            public const Int32 PRINTER_ACCESS_ADMINISTER = 0x4;
            public const Int32 PRINTER_ACCESS_USE = 0x8;
            public const Int32 STANDARD_RIGHTS_REQUIRED = 0xf0000;
            public const int PRINTER_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE);
            //added this 
            public const int CCHDEVICENAME = 32;
            //added this 
            public const int CCHFORMNAME = 32;
    
            #endregion
    
            #region Public Methods
    
    
            /// <summary>
            /// Method Name : GetPrinterDuplex 
            /// Programmatically get the Duplex flag for the specified printer 
            /// driver's default properties. 
            /// </summary>
            /// <param name="sPrinterName"> The name of the printer to be used. </param>
            /// <param name="errorMessage"> this will contain error messsage if any. </param>
            /// <returns> 
            /// nDuplexSetting - One of the following standard settings: 
            /// 0 = Error
            /// 1 = None (Simplex)
            /// 2 = Duplex on long edge (book) 
            /// 3 = Duplex on short edge (legal) 
            /// </returns>
            /// <remarks>
            /// </remarks>
            public short GetPrinterDuplex(string sPrinterName, out string errorMessage)
            {
                errorMessage = string.Empty;
                short functionReturnValue = 0;
                IntPtr hPrinter = default(IntPtr);
                PRINTER_DEFAULTS pd = default(PRINTER_DEFAULTS);
                DEVMODE dm = new DEVMODE();
                int nRet = 0;
                pd.DesiredAccess = PRINTER_ACCESS_USE;
                nRet = OpenPrinter(sPrinterName, out hPrinter, ref pd);
                if ((nRet == 0) | (hPrinter.ToInt32() == 0))
                {
                    if (GetLastError() == 5)
                    {
                        errorMessage = "Access denied -- See the article for more info.";
                    }
                    else
                    {
                        errorMessage = "Cannot open the printer specified " + "(make sure the printer name is correct).";
                    }
                    return functionReturnValue;
                }
                nRet = DocumentProperties(IntPtr.Zero, hPrinter, sPrinterName, IntPtr.Zero, IntPtr.Zero, 0);
                if ((nRet < 0))
                {
                    errorMessage = "Cannot get the size of the DEVMODE structure.";
                    goto cleanup;
                }
                IntPtr iparg = Marshal.AllocCoTaskMem(nRet + 100);
                nRet = DocumentProperties(IntPtr.Zero, hPrinter, sPrinterName, iparg, IntPtr.Zero, DM_OUT_BUFFER);
                if ((nRet < 0))
                {
                    errorMessage = "Cannot get the DEVMODE structure.";
                    goto cleanup;
                }
                dm = (DEVMODE)Marshal.PtrToStructure(iparg, dm.GetType());
                if (!Convert.ToBoolean(dm.dmFields & DM_DUPLEX))
                {
                    errorMessage = "You cannot modify the duplex flag for this printer " + "because it does not support duplex or the driver " + "does not support setting it from the Windows API.";
                    goto cleanup;
                }
                functionReturnValue = dm.dmDuplex;
    
                cleanup:
                if ((hPrinter.ToInt32() != 0))
                    ClosePrinter(hPrinter);
                return functionReturnValue;
            }
    
    
            /// <summary>
            /// Method Name : SetPrinterDuplex     
            /// Programmatically set the Duplex flag for the specified printer driver's default properties. 
            /// </summary>
            /// <param name="sPrinterName"> sPrinterName - The name of the printer to be used. </param>
            /// <param name="nDuplexSetting"> 
            /// nDuplexSetting - One of the following standard settings: 
            /// 1 = None 
            /// 2 = Duplex on long edge (book) 
            /// 3 = Duplex on short edge (legal) 
            /// </param>
            ///  <param name="errorMessage"> this will contain error messsage if any. </param>
            /// <returns>
            /// Returns: True on success, False on error.
            /// </returns>
            /// <remarks>
            /// 
            /// </remarks>
            public bool SetPrinterDuplex(string sPrinterName, int nDuplexSetting, out string errorMessage)
            {
                errorMessage = string.Empty;
                bool functionReturnValue = false;
                IntPtr hPrinter = default(IntPtr);
                PRINTER_DEFAULTS pd = default(PRINTER_DEFAULTS);
                PRINTER_INFO_9 pinfo = new PRINTER_INFO_9();
                DEVMODE dm = new DEVMODE();
                IntPtr ptrPrinterInfo = default(IntPtr);
                int nBytesNeeded = 0;
                int nRet = 0;
                Int32 nJunk = default(Int32);
                if ((nDuplexSetting < 1) | (nDuplexSetting > 3))
                {
                    errorMessage = "Error: dwDuplexSetting is incorrect.";
                    return functionReturnValue;
                }
                pd.DesiredAccess = PRINTER_ACCESS_USE;
                nRet = OpenPrinter(sPrinterName, out hPrinter, ref pd);
                if ((nRet == 0) | (hPrinter.ToInt32() == 0))
                {
                    if (GetLastError() == 5)
                    {
                        errorMessage = "Access denied -- See the article for more info.";
                    }
                    else
                    {
                        errorMessage = "Cannot open the printer specified " + "(make sure the printer name is correct).";
                    }
                    return functionReturnValue;
                }
                nRet = DocumentProperties(IntPtr.Zero, hPrinter, sPrinterName, IntPtr.Zero, IntPtr.Zero, 0);
                if ((nRet < 0))
                {
                    errorMessage = "Cannot get the size of the DEVMODE structure.";
                    goto cleanup;
                }
                IntPtr iparg = Marshal.AllocCoTaskMem(nRet + 100);
                nRet = DocumentProperties(IntPtr.Zero, hPrinter, sPrinterName, iparg, IntPtr.Zero, DM_OUT_BUFFER);
                if ((nRet < 0))
                {
                    errorMessage = "Cannot get the DEVMODE structure.";
                    goto cleanup;
                }
                dm = (DEVMODE)Marshal.PtrToStructure(iparg, dm.GetType());
                if (!Convert.ToBoolean(dm.dmFields & DM_DUPLEX))
                {
                    errorMessage = "You cannot modify the duplex flag for this printer " + "because it does not support duplex or the driver " + "does not support setting it from the Windows API.";
                    goto cleanup;
                }
                dm.dmDuplex = (short)nDuplexSetting;
                Marshal.StructureToPtr(dm, iparg, true);
                nRet = DocumentProperties(IntPtr.Zero, hPrinter, sPrinterName, pinfo.pDevMode, pinfo.pDevMode, DM_IN_BUFFER | DM_OUT_BUFFER);
                if ((nRet < 0))
                {
                    errorMessage = "Unable to set duplex setting to this printer.";
                    goto cleanup;
                }
                GetPrinter(hPrinter, 9, IntPtr.Zero, 0, ref nBytesNeeded);
                if ((nBytesNeeded == 0))
                {
                    errorMessage = "GetPrinter failed.";
                    goto cleanup;
                }
                ptrPrinterInfo = Marshal.AllocCoTaskMem(nBytesNeeded + 100);
                nRet = GetPrinter(hPrinter, 9, ptrPrinterInfo, nBytesNeeded, ref nJunk) ? 1 : 0;
                if ((nRet == 0))
                {
                    errorMessage = "Unable to get shared printer settings.";
                    goto cleanup;
                }
                pinfo = (PRINTER_INFO_9)Marshal.PtrToStructure(ptrPrinterInfo, pinfo.GetType());
                pinfo.pDevMode = iparg;
                pinfo.pSecurityDescriptor = 0;
                Marshal.StructureToPtr(pinfo, ptrPrinterInfo, true);
                nRet = SetPrinter(hPrinter, 9, ptrPrinterInfo, 0) ? 1 : 0;
                if ((nRet == 0))
                {
                    errorMessage = "Unable to set shared printer settings.";
                }
                functionReturnValue = Convert.ToBoolean(nRet);
                cleanup:
                if ((hPrinter.ToInt32() != 0))
                    ClosePrinter(hPrinter);
                return functionReturnValue;
            }
            #endregion
        }
    }
      
