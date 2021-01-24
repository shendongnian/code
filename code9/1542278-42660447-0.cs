    class Program
    {
        static void Main(string[] args)
        {
            double[,] A = {
                {1, 2},
                {3, 5}
            };
            double[] B = Vector.Ones(2);
            Console.WriteLine("A = \n{0}", Matrix.ToString(A));
            Console.WriteLine("\nB = \n{0}", Matrix.ToString(B));
            Console.WriteLine("\nAt*B/2 = \n{0}", Matrix.ToString(A.Transpose().Dot(B).Divide(2)));
            Console.ReadLine();
        }
    }
