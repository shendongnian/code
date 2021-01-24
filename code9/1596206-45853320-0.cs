    startAdvertisment: function (successCallback, errorCallback, args) {
    
            if (publisher === null) {
                publisher = Windows.Devices.WiFiDirect.WiFiDirectAdvertisementPublisher();
            }
    
            if (listener===null) {
                listener = new Windows.Devices.WiFiDirect.WiFiDirectConnectionListener();
    
                listener.onconnectionrequested = OnConnectionRequested;
            }
            publisher.advertisement.isAutonomousGroupOwnerEnabled = false;
    
            publisher.advertisement.listenStateDiscoverability =
                Windows.Devices.WiFiDirect.WiFiDirectAdvertisementListenStateDiscoverability.normal;
    publisher.start();
    
        }
