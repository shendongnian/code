    int capacity = 8192; // If you have some idea of the final string length.
    var sb = new StringBuilder(capacity);
    for (float x = 0; x < 1000; x += 1.2345f)
        sb.AppendFormat(", {0}", x);
    char[] array = new char[sb.Length];
            
    sb.CopyTo(0, array, 0, sb.Length); // Now array[] contains the result.
