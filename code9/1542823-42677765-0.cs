    const int BYTES_PER_DEVICE_NAME = 200;
    const char PADDING_VALUE = (char)205;
    const char NULL_VALUE = (char)0;
    
    IntPtr nameAddress = (IntPtr)myDLL.GetPointer();
    
    // Only run if the pointer is not to a null value
    if (nameAddress != IntPtr.Zero)
    {
        byte[] nameAsBytes = new byte[BYTES_PER_DEVICE_NAME];
        Marshal.Copy(nameAddress, nameAsBytes, 0, BYTES_PER_DEVICE_NAME);
        byte[] cleanedBytes = nameAsBytes.Where(a => a != PADDING_VALUE); //Filter out the bad bytes
        string nameAsString = System.Text.Encoding.UTF8.GetString(cleanedBytes);
    
        // Add the string to deviceNames, a string array
        deviceNames[n] = nameAsString;
    }
