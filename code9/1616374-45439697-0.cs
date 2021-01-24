    using NAudio.CoreAudioApi;
    
    MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
    
    MMDevice defaultDevice = devEnum.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Communications);
    
    defaultDevice.AudioEndpointVolume.Channels[0].VolumeLevel = 10;
    defaultDevice.AudioEndpointVolume.Channels[1].VolumeLevel = 6;
