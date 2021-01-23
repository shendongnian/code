    INPUT input = new INPUT {
        Type = 1
    };
    input.Data.Keyboard = new KEYBDINPUT() {
        Vk = 0x09,
        Scan = 0,
        Flags = 0,
        Time = 0,
        ExtraInfo = IntPtr.Zero,
    };
    INPUT input2 = new INPUT {
        Type = 1
    };
    input2.Data.Keyboard = new KEYBDINPUT() {
        Vk = 0x09,
        Scan = 0,
        Flags = 2,
        Time = 0,
        ExtraInfo = IntPtr.Zero
    };
    INPUT[] inputs = new INPUT[] { input, input2, input, input2, input, input2 };
    SendInput(6, inputs, Marshal.SizeOf(typeof(INPUT)));
