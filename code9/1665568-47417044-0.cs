    static void Main()
    {
        // pretend this isn't text
        byte[] bytes = Encoding.ASCII.GetBytes("askdjhkas*hdaskjdhakjshdjkahs*dkujyash");
        foreach(var chunk in Split(bytes, (byte)'*'))
        {
            // cheating with text to see if it worked
            var s = Encoding.ASCII.GetString(chunk.Array, chunk.Offset, chunk.Count);
            Console.WriteLine(s);
        }
    }
    static IEnumerable<ArraySegment<byte>> Split(byte[] data, byte splitBy)
    {
        int start = 0, end;
        while((end = Array.IndexOf<byte>(data, splitBy, start)) > 0)
        {
            yield return new ArraySegment<byte>(data, start, end - start);
            start = end + 1;
        }
        end = data.Length;
        if ((end - start) > 0)
        {
            yield return new ArraySegment<byte>(data, start, end - start);
        }
    }
