     public static void MergeSort(int[] A) // WIP
            {
                if (A.Length % 2 == 0)     //Checks if input array is even
                {
                    int[] B = new int[A.Length / 2];                //Declares sub array
                    int[] C = new int[A.Length / 2];                //Declares sub array
                    for (int x = 0; x < A.Length; x++)     //Performs an action for every item item in the array
                    {
                        if (x < A.Length / 2)               //selects the first half of the input array and assigns it to sub-Array B
                        {
                            B[x] = A[x];
                        }
                        if (x > A.Length / 2)                //Selects the second half of the input array and assigns it to sub-Array C
                        {
                            C[x] = A[x];
    
                        }
                    }
    
                }
            }
