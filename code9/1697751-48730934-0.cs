    var vendorId = UsbSetting.Instance.UsbDeviceInfo.PnpDeviceId.Split('\\', '&').
                            SingleOrDefault((s) => s.Contains(UsbInfo.Vid.Description()))?.
                            Replace(UsbInfo.Vid.Description()+"_", ""); 
    var productId = UsbSetting.Instance.UsbDeviceInfo.PnpDeviceId.Split('\\', '&').
                            SingleOrDefault((s) => s.Contains(UsbInfo.Pid.Description()))?.
                            Replace(UsbInfo.Pid.Description() + "_", "");
