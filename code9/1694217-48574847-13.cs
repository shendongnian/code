    [DllImport("winmm.dll", SetLastError = true)]
    private static extern MMRESULT midiInOpen(out HMIDIIN lphMidiIn, UIntPtr uDeviceID,
            MidiInProc dwCallback, UIntPtr dwCallbackInstance, MidiOpenFlags dwFlags);
    [StructLayout(LayoutKind.Sequential)]
    public struct HMIDIIN
    {
       public IntPtr handle;
    }
    public enum MMRESULT : uint
    {
       // General return codes.
       MMSYSERR_BASE = 0,
       MMSYSERR_NOERROR = MMSYSERR_BASE + 0,
       ...
    }
    
    public enum MidiOpenFlags : uint
    {
       CALLBACK_TYPEMASK = 0x70000,
       CALLBACK_NULL = 0x00000,
       ...
    }
    public enum MidiInMessage : uint
    {
       MIM_OPEN = 0x3C1,
       MIM_CLOSE = 0x3C2,
       ...
    }
