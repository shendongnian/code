       public IntPtr dwData;    // Any value the sender chooses.  Perhaps its main window handle?
       public int cbData;       // The count of bytes in the message.
       public IntPtr lpData;    // The address of the message.
    }
    
    const int WM_COPYDATA = 0x004A;
