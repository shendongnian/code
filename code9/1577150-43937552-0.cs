        static void Main(string[] args)
        {
            Random r = new Random();
            double[][] inputs = new double[10][];
            int[] outputs = new int[10];
            for (int i = 0; i < 10; i++)
            {
                inputs[i] = new double[8];
                for (int j = 0; j < 8; j++)
                {
                    inputs[i][j] = r.Next(1, 100);
                }
                outputs[i] = r.Next(1, 6);
            }
            var smo = new MulticlassSupportVectorLearning<DynamicTimeWarping>()
            {
                Learner = (param) => new SequentialMinimalOptimization<DynamicTimeWarping>()
                {
                    Kernel = new DynamicTimeWarping(alpha: 1, degree: 1),
                }
            };
            
            var svm = smo.Learn(inputs, outputs);
            int[] predicted = svm.Decide(inputs);
            double error = new ZeroOneLoss(outputs).Loss(predicted);
            Console.WriteLine();
            Console.WriteLine("output = \n{0}", Matrix.ToString(outputs));
            Console.WriteLine();
            Console.WriteLine("predicted = \n{0}", Matrix.ToString(predicted));
            Console.WriteLine();
            Console.WriteLine("error = {0}", error);
            Console.ReadLine();
        }
