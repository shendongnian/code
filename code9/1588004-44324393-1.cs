    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork nn = new NeuralNetwork();
            double[] inputs = new double[] { 0.3, -5.6, 4.8, 7.2 };
            double[] results = nn.ComputeOutputs(inputs);
            Console.WriteLine("Neural Network Results:");
            foreach(double v in results)
            {
                Console.Write(v.ToString("0.00"));
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
