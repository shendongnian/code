    string x = GetYouHexString();
    x = x.Remove(0,2);
    string[] stringArr = Enumerable.Range(0, x.Length / 2)
                                   .Select(i => x.Substring(i * 2, 2))
                                   .ToArray();
    byte[] byteArr = Array.ConvertAll(stringArr , b => Convert.ToByte(b, 16));
