    private static string IntsToBase64(IEnumerable<int> lst)
    {
        var arr = lst.SelectMany(i => BitConverter.GetBytes(i))
                        .ToArray();
        return Convert.ToBase64String(arr);
    }
    private static IEnumerable<int> Base64ToInts(string base64)
    {
        var buffer = Convert.FromBase64String(base64);
        for (var i = 0; i < buffer.Length; i += 4)
            yield return BitConverter.ToInt32(buffer, i);
    }
