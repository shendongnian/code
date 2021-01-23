    public object[,] clear_array_nulls(object[,] input)
        {
            int m = input.GetUpperBound(0);
            int n = input.GetUpperBound(1) + 1;
            object[] temp = new object[input.GetUpperBound(0)];
            for (int x = 0; x < m; x++)
                temp[x] = input[x, 0];
            temp = temp.Where(s => !object.Equals(s, null)).ToArray();
            object[,] output = new object[temp.Length, n];
            Array.Copy(input, output, temp.Length * n);
            return output;
        }
