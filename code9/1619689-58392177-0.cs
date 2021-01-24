    public static bool SendStringToPrinterUTF8(string szPrinterName, string szString)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(szString);
                MemoryStream stream = new MemoryStream(byteArray); 
                BinaryReader br = new BinaryReader(stream);
                Byte[] bytes = new Byte[stream.Length];
                IntPtr pUnmanagedBytes = new IntPtr(0);
                int nLength;
                nLength = Convert.ToInt32(stream.Length);
                bytes = br.ReadBytes(nLength);
                pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
                Marshal.FreeCoTaskMem(pUnmanagedBytes);
                return true;
            }
    public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.
                di.pDocName = "Printing UCC Labels";
                di.pDataType = "RAW";
                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }
