    void DoAudio(VlcMediaPlayer player)
    {
        IAudioManagement audioMgt = player.Audio;
    
        foreach(AudioOutputDescriptions descriptions in audioMgt.Outputs.All){
    
            foreach(AudioOutputDevice device in description.Devices){
                //enumerate them for display
                string audioName = device.LongName;
    
                // Or set it as output
                device.SetAsCurrent();
            }
    }
