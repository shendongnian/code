                int[] testArray = new int[] { 1, 2, 3, 4, 5 };
                Dictionary<int, int[]> convertData = new Dictionary<int, int[]>();
    
                foreach (int x in testArray)
                {
                    System.Collections.BitArray b = new System.Collections.BitArray(Convert.ToByte(x));
                    convertData[x] = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();
                }
