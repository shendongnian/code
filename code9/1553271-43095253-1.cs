    MqttClient client = new MqttClient(
        endPoint,
        MqttSettings.MQTT_BROKER_DEFAULT_SSL_PORT,
        true,
        rootCa,
        new X509Certificate2(@"certificate.pfx", @""); // My PFX was created with a blank password, hence empty string as 2nd arg
        MqttSslProtocols.TLSv1_2
        );
    client.Connect(Guid.NewGuid().ToString());
