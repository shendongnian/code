    public static void onMessage(IntPtr str) {
        int length = 0;//循环查找字符串的长度
        while (Marshal.ReadByte(str + length) != 0) {
            length++;
        }
        byte[] strbuf = new byte[length];
        Marshal.Copy(str, strbuf, 0, length);
        // Taken from https://msdn.microsoft.com/it-it/library/system.text.encodinginfo.getencoding(v=vs.110).aspx
        string message1 = Encoding.UTF8.GetString(strbuf);
        string message2 = Encoding.GetEncoding(54936).GetString(strbuf);
        string message3 = Encoding.GetEncoding(936).GetString(strbuf);
        string message4 = Encoding.GetEncoding(950).GetString(strbuf);
        string message5 = Encoding.GetEncoding(10002).GetString(strbuf);
        string message6 = Encoding.GetEncoding(10008).GetString(strbuf);
        string message7 = Encoding.GetEncoding(20000).GetString(strbuf);
        string message8 = Encoding.GetEncoding(20002).GetString(strbuf);
        string message9 = Encoding.GetEncoding(20936).GetString(strbuf);
        string message10 = Encoding.GetEncoding(50227).GetString(strbuf);
        string message11 = Encoding.GetEncoding(51936).GetString(strbuf);
        string message12 = Encoding.GetEncoding(52936).GetString(strbuf);
    }
