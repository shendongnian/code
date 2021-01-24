        void Main()
        {
            Print(new double[][]
            {
                new double[] { 1, 2 },
                new double[] { 3, 4 },
                new double[] { 5, 6 },
            });
            // Output: [ 1, 2 ]
            //         [ 3, 4 ]
            //         [ 5, 6 ]
        }
        static void Print(dynamic array)
        {
            if (array.Length == 0)
                return;
            if (array[0].GetType().IsArray)
            {
                foreach (var element in array)
                {
                    Print(element);
                }
            }
            else
            {
                int size = array.Length;
                string str = "[ ";
                for (int i = 0; i < size; i++)
                {
                    str += array[i].ToString();
                    if (i < size - 1)
                        str += ", ";
                }
                str += " ]";
                Console.WriteLine(str);
            }
        }
