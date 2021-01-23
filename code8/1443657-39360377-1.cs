    byte[] result = new byte[10];
    Array.Copy(BitConverter.GetBytes(data.a), 0, result, 0, 4);
    Array.Copy(BitConverter.GetBytes(data.b), 1, result, 4, 3);
    Array.Copy(BitConverter.GetBytes(data.c), 2, result, 7, 2);
    Array.Copy(BitConverter.GetBytes(data.c), 3, result, 9, 1);
