    SMS_Service.SMS_ServiceClient client = new SMS_Service.SMS_ServiceClient();
    client.Endpoint.Address = new EndpointAddress(new Uri("http://10.20.5.100:9998/SMS_Service"), client.Endpoint.Address.Identity, client.Endpoint.Address.Headers);
    client.Open();
    client.DoWork("test");
    client.Close();
