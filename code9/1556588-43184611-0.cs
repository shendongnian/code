    uint index = 0;
    var error = ETrackedPropertyError.TrackedProp_Success;
    for (uint i = 0; i < 16; i++)
    {
        var result = new System.Text.StringBuilder((int)64);
        OpenVR.System.GetStringTrackedDeviceProperty(i, ETrackedDeviceProperty.Prop_RenderModelName_String, result, 64, ref error);
        if (result.ToString().Contains("tracker"))
        {
            index = i;
            break;
        }
    }
    
