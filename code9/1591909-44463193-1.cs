    static int[] intConvertedList(string[] arr3)
        {
            int[] intConvertedList = new int[arr3.Length];
            for (int i = 0; i < intConvertedList.Length; i++)
            {
                intConvertedList[i] = int.Parse(arr3[i]);
            }
            return intConvertedList;
        }
