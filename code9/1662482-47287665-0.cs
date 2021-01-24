     static void Main(string[] args)
        {
            
            Program A = new Program();
            string[] array = System.IO.File.ReadAllLines(@"C:\Users\dawid\Desktop\C#\Heapsort\dane.txt");
            int[] arrayInt = Array.ConvertAll(array, int.Parse);
            A.BuildHeap(arrayInt, arrayInt.Length);
            A.HeapSort(arrayInt, arrayInt.Length);
            Console.WriteLine(string.Join(" ", arrayInt));
            Console.ReadLine();
        }
