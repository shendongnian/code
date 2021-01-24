       using System.Linq;
       ... 
       string hl7 = @"MSH|^~\&|||...|@DSC||@";
       byte[] msg = (new byte[] { 0x0b })
        .Concat(Encoding.ASCII.GetBytes(hl7).Select(b => b != 64 ? b : (byte)0x0d))
        .Concat(new byte[] { 0x1c, 0x0d })
        .ToArray();
       tcpServer.Send(client, msg);
