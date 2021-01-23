    var bits = new byte[4];
    bits[0] = 0x41;
    bits[1] = 0x42;
    bits[2] = 0x43;
    bits[3] = 0;
    string result = System.Text.Encoding.ASCII.GetString(bits);
