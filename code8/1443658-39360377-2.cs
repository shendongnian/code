    byte[] result = new byte[10];
    Array.Copy(BitConverter.GetBytes(data.a), 0, result, 0, 4);
    Array.Copy(BitConverter.GetBytes(data.b), 0, result, 4, 3);
    Array.Copy(BitConverter.GetBytes(data.c), 0, result, 7, 2);
    Array.Copy(BitConverter.GetBytes(data.d), 0, result, 9, 1);
