    [assembly: Xamarin.Forms.Dependency(typeof(UniqueIdWinPhone))]
    namespace UniqueId.WinPhone
    {
        public class UniqueIdWinPhone : IDevice
        {
            public string GetIdentifier()
            {
                byte[] myDeviceId = (byte[])Microsoft.Phone.Info.DeviceExtendedProperties.GetValue("DeviceUniqueId");
                return Convert.ToBase64String(myDeviceId);
            }
        }
    }
