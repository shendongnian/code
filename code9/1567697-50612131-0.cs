    public void ReadValueFromOPC(string host, string userName, string password)
        {
            var options = new UaClientOptions
            {
                UserIdentity = new Opc.Ua.UserIdentity(
                    userName,
                    password)
            };
            using (var client = new UaClient(new Uri("opc.tcp://" +
                host), options))
            {
                client.Connect();
                var node = client.FindNode("SomeTag.SomeChildTag");
                // Find out what the type is before you try to get the value
                Type type = client.GetDataType(node.Tag);
                // If you find out it's a UInt32 then you use it.
                var value = client.Read<UInt32>(node.Tag).Value;
            }
        }
