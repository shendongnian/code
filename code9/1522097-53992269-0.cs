        int[] arr = { 1, 2, 3, 5, 4, 3, 3, 4, 5, 6, 5, 4, 5, 6, 7, 8, 7, 5, 6, 9, 8, 7, 0 };
            int pos = 0, bestPos = 0, bestLen = 0;
            int len = 1; 
            for(int i = 0; i < arr.Length -1; i++)
            {
                if(arr[i] + 1 == arr[i + 1])
                {
                    len++;
                    if(len > bestLen)
                    {
                        bestLen = len;
                        bestPos = pos; 
                    }
                }
                else
                {
                    len = 1;
                    pos = i ;
                }
            }
            for( int k = bestPos; k <= bestLen + bestPos; k++)
            {
                Console.Write("{0}", arr[k]);
            }
