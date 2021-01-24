    var endPointAddress = new EndpointAddress("http://DEVICE_IPADDRESS/onvif/device_service");
                var httpTransportBinding = new HttpTransportBindingElement { AuthenticationScheme = AuthenticationSchemes.Digest };
                var textMessageEncodingBinding = new TextMessageEncodingBindingElement { MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None) };
                var customBinding = new CustomBinding(textMessageEncodingBinding, httpTransportBinding);
                var passwordDigestBehavior = new PasswordDigestBehavior(USERNAME, PASSWORD);
                var deviceService = new DeviceClient(customBinding, endPointAddress);
                deviceService.Endpoint.Behaviors.Add(passwordDigestBehavior);
