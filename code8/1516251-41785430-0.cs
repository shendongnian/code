        public static Format GetFormat(string format) {
            lock(internalSyncObject) {
                EnsurePredefined();
 
                // It is much faster to do a case sensitive search here.  So do 
                // the case sensitive compare first, then the expensive one.
                //
                for (int n = 0; n < formatCount; n++) {
                    if (formatList[n].Name.Equals(format))
                        return formatList[n];
                }
                
                for (int n = 0; n < formatCount; n++) {
                    if (String.Equals(formatList[n].Name, format, StringComparison.OrdinalIgnoreCase))
                        return formatList[n];
                }
        
                // need to add this format string
                //
                int formatId = SafeNativeMethods.RegisterClipboardFormat(format);
                if (0 == formatId) {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), SR.GetString(SR.RegisterCFFailed));
                }
        
 
                EnsureFormatSpace(1);
                formatList[formatCount] = new Format(format, formatId);
                return formatList[formatCount++];
            }
        }
