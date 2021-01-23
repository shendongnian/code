     public void SetVolume(int volume)
     {
        var command = "setaudio MediaFile volume to " + volume.ToString();
        mciSendString(command, null, 0, IntPtr.Zero);
     }
