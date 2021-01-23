            var deviceEnum = new MMDeviceEnumerator();
            var devices = deviceEnum.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active).ToList();
            foreach (MMDevice device in devices)
            {
                Console.WriteLine(device.FriendlyName);
                if (device.Properties.Contains(PropertyKeys.PKEY_AudioEndpoint_PhysicalSpeakers))
                {
                    var value = device.Properties[PropertyKeys.PKEY_AudioEndpoint_PhysicalSpeakers];
                    Console.WriteLine("Current value: " + value.Value.ToString());
                    // set configuration to 5.1, value is taken from ksmedia.h from Windows Driver Kit
                    PropVariant newvalue = PropVariant.FromLong(63);
                    device.Properties.SetValue(PropertyKeys.PKEY_AudioEndpoint_PhysicalSpeakers, newvalue);
                }
            }
