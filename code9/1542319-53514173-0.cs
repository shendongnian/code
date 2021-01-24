    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayData = { 10,25,33,45,88,99,22,11,66,44,23};
            for(int i = 0; i < arrayData.Length - 1; i++)
            {
                int minValue = i;
                for(int j = i + 1; j < arrayData.Length; j++)
                {
                    if (arrayData[j] < arrayData[minValue])
                    {
                        minValue = j;
                    }
                }
                /*Swap Code*/
                int tempData = arrayData[minValue];
                arrayData[minValue] = arrayData[i];
                arrayData[i] = tempData;
            }
            /*Print Code*/
            for(int i = 0; i < arrayData.Length; i++)
            {
                Console.Write(arrayData[i]+"\t");
            }
            Console.ReadLine();
        }
    }
