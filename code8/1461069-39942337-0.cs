    int[] sensorMaskList = new int[length] {1, 2, 4, 8,... };
    internal List<int> GetSelectedData(byte[] byteMask)
    {
        BitArray byteMaskBits = new BitArray(byteMask);
        List<int> lstDataIndex = new List<int>();
        for (int i = 0; i < sensorMaskList.Length; i++)
        {
            byte[] mask = BitConverter.GetBytes(sensorMaskList[i]);
            BitArray maskBits = new BitArra(mask);
            if(maskBits.And(byteMaskBits))
            {
                lstDataIndex.Add(i);
            }
         }
         return lstDataIndex;
    }
