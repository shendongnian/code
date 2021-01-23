    var thisByte = string.Empty;
    foreach (char c in BinaryString)
    {
        thisByte += c;
        if (thisByte.Length == 8)
        {
            bytes.Add(Convert.ToByte(thisByte, 2));
            thisByte = string.Empty;
        }
    }
