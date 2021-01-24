        [System.Security.SecuritySafeCritical]  // auto-generated
        [System.Runtime.Versioning.NonVersionable]
        public unsafe static explicit operator int (IntPtr  value) 
        {
            #if WIN32
                return (int)value.m_value;
            #else
                long l = (long)value.m_value;
                return checked((int)l);
            #endif
        }
