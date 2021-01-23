        private static void ReDimMultiObjects(ref object[,] arr, int length)
        {
            object[,] arrTemp = new object[length, 3];//New number of objects, and 3 elements in each object
            if (length > arr.Length / 3)//Array Length is always total elements - would be 15 for 5 objects with 3 elements each
            {
                Array.Copy(arr, 0, arrTemp, 0, arr.Length);
                arr = arrTemp;
            }
            else
            {
                Array.Copy(arr, 0, arrTemp, 0, length * 3);
                arr = arrTemp;
            }
        }
