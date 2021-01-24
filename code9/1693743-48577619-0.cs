            byte[] serializedBytes;
            ContainerMessage containerMessage = new ContainerMessage()
            {
                Connect = new Connect()
                {
                    ClientName = "TemporaryClientName",
                },
                Type = CommandType.Connect,
            };
            using( MemoryStream stream = new MemoryStream())
            {
                containerMessage.WriteTo(stream);
                serializedBytes = stream.ToArray();
            }
            ContainerMessage parsedCopy = ContainerMessage.Parser.ParseFrom(serializedBytes);
