        class Program
        {
            static void Main(string[] args)
            {
                //Made those in same size to not throw an exception
                int[] array1Key = new int[] { 0, 1, 3, 7 };
                int[] array1Values = new int[] { 5, 7, -3, 9 };
    
                int[] array2Key = new int[] { 0, 2, 3, 4 };
                int[] array2Values = new int[] { 2, 4, 4, 8 };
                
                //Create Polinomio object which will serve as `Dictionary<>` in this case
                Polinomio polinomio1 = new Polinomio();
                Polinomio polinomio2 = new Polinomio();
    
                for (int i = 0; i < array1Key.Length; i++)
                {
                    polinomio1.Add(array1Key[i], array1Values[i]);
                }
                for (int i = 0; i < array2Key.Length; i++)
                {
                    polinomio2.Add(array2Key[i], array2Values[i]);
                }
                Dictionary<int, int> sum = polinomio1 + polinomio2;
                for (int i = 0; i < sum.Count; i++)
                {
                    Console.WriteLine($"{sum.Keys.ElementAt(i)} {sum.Values.ElementAt(1)}");
                }
                Console.ReadLine();
            }
    
        }
        public class Polinomio : Dictionary<int, int> //inheritance
        {
            public static Dictionary<int, int> operator +(Polinomio p1, Polinomio p2)
            {
                if (p1.Count != p2.Count)
                {
                    throw new Exception("Not the same Size");
                }
                Dictionary<int, int> dictionaryTemp = new Dictionary<int, int>();
                for (int i = 0; i < p1.Count; i++)
                {
                    dictionaryTemp.Add(p1.Keys.ElementAt(i) + p1.Keys.ElementAt(i), p1.Values.ElementAt(i) + p2.Values.ElementAt(1));
                }
                return dictionaryTemp;
            }
        }
