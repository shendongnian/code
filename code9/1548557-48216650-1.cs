    AudioInputDevices audioDevice = new AudioInputDevices();
    audioDevice.FriendlyName = device.FriendlyName;
    audioDevice.DeviceFriendlyName = device.DeviceFriendlyName;
    audioDevice.State = device.State.ToString();
    audioDevice.SampleRate = device.AudioClient.MixFormat.SampleRate.ToString();
