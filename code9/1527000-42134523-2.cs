    foreach(char c in meString)
    {
        if(c >= '0' && c <= '9')
            result.Add((int)(c - 0x30));
    }
    // then to copy to array :
    int[] arr = new int[result.Count];
    result.CopyTo(arr);
