    List<byte[]> byteArrayList = new List<byte[]>();
    byteArrayList.Add(new byte[] { 1, 2, 3, 5, 9, 6, 7, 6, 45, 50, 39 });
    byteArrayList.Add(new byte[] { 0, 1, 0, 1, 0, 1, 0, 1, 99, 99, 99, 99, 99, 99 });
    byteArrayList.Add(new byte[] { 2, 2, 2, 2, 3, 3, 3, 3 });
    byteArrayList.Add(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 31, 21 });
    byteArrayList.Add(new byte[] { 1, 22, 32, 22, 3, 3, 3, 3, 12, 13, 14, 15 });
    byteArrayList.Add(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 95, 85, 75 });
    List<byte[]> result = SortFromIndex(byteArrayList, 2);
