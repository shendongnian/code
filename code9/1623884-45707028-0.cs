    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            while (command != "exit")
            {
                XDocument xml = XDocument.Parse(xmlString);
                Console.WriteLine("Find packet: ");
                command = Console.ReadLine();
  
                var element = xml
                      .Descendants()
                      .FirstOrDefault(x => x.Attribute("name")?.Value == command);
                if (element == null)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    Console.WriteLine(element.Value);
                }
                Console.WriteLine(new string('-', 20));
            }
        }
        static string xmlString = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                                <Packets>
                                  <ConnectionPackets>
                                    <PacketType name=""Handshake""> HANDSHAKE </PacketType >
                                    <PacketType name=""HandshakeAcknowledgement"">HANDSHAKE_ACKNOWLEDGEMENT</PacketType>
                                  </ConnectionPackets>
                                  <ClientMessagePackets>
                                    <PacketType name=""ClientLoginRequest"" > CLIENTPC_LOGIN_REQUEST </PacketType >
                                    <PacketType name=""ClientLoginResponse"">CLIENTPC_LOGIN_RESPONSE</PacketType>
                                  </ClientMessagePackets>
                                </Packets>";
        
    }
