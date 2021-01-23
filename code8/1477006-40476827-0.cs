        static void countingSort(int[] arr)
        {
            int i, j, max = -1; 
            int[] values;
            //get the highest absolute value to determine the size of the array 
            for (i = 0; i < arr.Length; i++)
                if (Math.Abs(arr[i]) > max) max = Math.Abs(arr[i]);
            //create double the max size array
            values = new int[max*2 + 1];
            //when reaching a value make a shift of max size            
            for (i = 0; i < arr.Length; i++)
                values[arr[i]+max]++;
            i = 0; j = values.Length - 1;
            while (i < arr.Length)
            {
                if (values[j] > 0)
                {
                    values[j]--;
                    //shift back when putting in the sorted array
                    arr[i] = j-max;
                    i++;
                }
                else j--;
            }
           
        }
