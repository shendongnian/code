        static void Main(string[] args)
        {
            double[][] inputs =
             {
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
                new double[] { 0, 1, 1, 0 },
             };
            var oteacher = new OneclassSupportVectorLearning<ChiSquare, double[]>();
            var k = oteacher.Learn(inputs);
            var m = k.Decide(new double[] { 1, 0, 0, 1 });
            var n = k.Decide(new double[] { 0, 1, 1, 0 });
            Console.WriteLine("Anomaly = {0}", m);
            Console.WriteLine("Anomaly = {0}", n);
            Console.ReadLine();
        }
