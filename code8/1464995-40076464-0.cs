    public class ArrayHelper
    {
        public static string PrintArray (int [,] arr)
        {
            string output = "";
            for (int i = 0; i<arr.GetLength(0);i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    output += arr[i,j];
                output = output.Substring(0, output.Length)+"/n";
            }
            return output;
        }
        public static void Fill(int[,] arr,int min, int max)
        {
            Random r = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i] = r.Next(min, max);
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i,j] = r.Next(min, max);
                }
            }
        }
    }
