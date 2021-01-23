        public static int[] Concat(int[] array1, int[] array2) //array1 = 1, 2, 3, 4, 5 array2 = 6, 7, 8, 9, 10.
        {
            int i = array1.Length; // + 1;
            int[] array3 = new int[array1.Length + array2.Length];
            Class1.CopyTo(array1, array3, 0);
            Class1.CopyTo(array2, array3, i);
            Class1.PrettyPrint(array3);
            return array3;
        }
