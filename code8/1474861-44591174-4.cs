    using System;
    
    public class SortProblem
    {
        public static void Main()
        {
            Sort();
            Console.ReadKey();
        }
        public static void Sort()
        {
            var a = new[]
            {
                10, 10, 5, 2, 2, 5, 6, 7, 8, 15, 4, 4, 4, 2, 3, 5, 5, 36, 32, 623, 7, 475, 7, 2, 2, 44, 5, 6, 7, 71, 2
            };
            Max_elements(a);
            Console.WriteLine();
            Sort_elements(a);
        }
        private static void Max_elements(int[] a)
        {
            /*"індекс" = 0 */
            for (int index = 0; index < a.Length; index++)
            {
                /*Знаходить у списку найбільше значення таке,
                 *що його позиція дорівнює або більша за "index"
                 *(справа від елемента на позиції "індекс")*/
                int maxPos = index, tmp;
                /* відсортує заданий масив "a"
                 * у порядку спадання "elemIndex < a"
                 * за допомогою алгоритму сортування вибором ".Length"*/
                for (int elemIndex = index + 1; elemIndex < a.Length; elemIndex++)
                {
                    /*Якщо елемент на позиції elemIndex
                     *більше елемента на позиції maxPos,
                     *то необхідно онвити значення "індекс"*/
                    if (a[elemIndex] > a[maxPos])
                    {
                        maxPos = elemIndex;
                    }
                }
                /*Міняє його місцями з елементом масиву на позиції "індекс"*/
                tmp = a[index];
                a[index] = a[maxPos];
                a[maxPos] = tmp;
                /*виводимо всі позиції максимального елемента і пробіл після неї*/
                Console.Write($"{maxPos} ");
                /*Рядок, який передує символ $ називається Інтерпольований рядок.
                 Інтерпольовані рядки можуть містити вирази взяті у фігурні дужки {}*/
            }
        }
        
        private static void Sort_elements(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                /*виводимо всі елементи відсортованого масиву і пробіл після неї*/
                Console.Write($"{a[i]} ");
            }
        }   
    }
