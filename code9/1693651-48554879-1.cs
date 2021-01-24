    //using System.Linq;
    byte[] results = m_streams.SelectMany
    ( 
        s =>
        {
            var buffer = new byte[s.Length];
            s.Read(buffer, 0, (int)s.Length);
            return buffer;
        }
    }.ToArray(); 
