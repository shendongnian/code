    public List<USB_COMPANION_INFO> GetUsbCompanions()
    {
                USB_COMPANION_INFO compInfoUSB = new USB_COMPANION_INFO();
                List<USB_COMPANION_INFO> usbCompanions = new List<USB_COMPANION_INFO>();
    
                int pdwSize = 0;
                int pdwEntries = 0;
                int result = 0;
    
                pdwSize = Marshal.SizeOf(typeof(USB_COMPANION_INFO));
                result = apiGetUsbCompanions(compInfoUSB, ref pdwSize, ref pdwEntries);
                // Retry getting data info if Name is null or empty (Sometimes it fails getting information). Only apply for USB.
                if (pdwEntries > 0 && string.IsNullOrEmpty(compInfoUSB.szName))
                {
                    // Reset communication to force to stop service
                    StopCommunication();
                    result = apiGetUsbCompanions(compInfoUSB, ref pdwSize, ref pdwEntries);
                }
    
                if (pdwEntries > 0)
                {
                    for (int i = 0; i < pdwEntries; i++)
                    {
                        usbCompanions.Add(compInfoUSB);
                    }
                }
    
                return usbCompanions;
     }
