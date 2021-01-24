    static void Main(String[] args) {
            string sNumbers = "1,2,3,4,5";
            int sum = 0;           
            int[] array = sNumbers.Split(',').Select(str => int.Parse(str)).ToArray();
            for (int i = 0; i < array.Length; i++) {
                sum = sum + array[i];
            }
            string sumString = string.Join(" + ", array) + " = ";
            Console.WriteLine(sumString + sum);
            Console.ReadKey();           
        }
