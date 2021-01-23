    string selectedDeviceName = "";
    WebCamDevices[] allDevices = WebCamTexture.devices;
    for(int i = 0; i < allDevices.Length; i++)
    {
        if (allDevices[i].isFrontFacing)
        {
            selectedDeviceName = allDevices[i].name;
            break;
        }
    }
   
    this.cameraTexture = new WebCamTexture(selectedDeviceName, 960, 640);
