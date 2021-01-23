            // this is the sequence y follows
        int[] ysequence = new int[] { 1, 2, 3, 2 };
        // this generates the correct Y for a given X
        int CalcY(int x) => ysequence[(x - 1) % 4];
        // this generates some inputs - just a few differnt mod of x
        int[] CalcInputs(int x) => new int[] { CalcY(x-1), CalcY(x-2), CalcY(x-3), CalcY(x-4), CalcY(x - 5) };
        //int[] CalcInputs(int x) => new int[] { x % 2, x % 3, x % 4, x % 5, x % 6 };
        // for http://stackoverflow.com/questions/40573388/simple-accord-net-machine-learning-example
        [TestMethod]
        public void AccordID3TestTestStackOverFlowQuestion2()
        {
            // build the training data set
            int numtrainingcases = 12;
            int starttrainingat = 9;
            int[][] inputs = new int[numtrainingcases][];
            int[] outputs = new int[numtrainingcases];
            Console.WriteLine("\t\t\t\t x \t y");
            for (int x = starttrainingat; x < numtrainingcases + starttrainingat; x++)
            {
                int y = CalcY(x);
                inputs[x- starttrainingat] = CalcInputs(x);
                outputs[x- starttrainingat] = y;
                Console.WriteLine("TrainingData \t " +x+"\t "+y);
            }
            // define how many values each input can have
            DecisionVariable[] attributes =
            {
                new DecisionVariable("y-1",4),
                new DecisionVariable("y-2",4),
                new DecisionVariable("y-3",4),
                new DecisionVariable("y-4",4),
                new DecisionVariable("y-5",4)
            };
            // define how many outputs (+1 only because y doesn't use zero)
            int classCount = outputs.Max()+1;
            // create the tree
            DecisionTree tree = new DecisionTree(attributes, classCount);
            // Create a new instance of the ID3 algorithm
            ID3Learning id3learning = new ID3Learning(tree);
            // Learn the training instances! Populates the tree
            id3learning.Learn(inputs, outputs);
            Console.WriteLine();
            // now try to predict some cases that werent in the training data
            for (int x = starttrainingat+numtrainingcases; x <= starttrainingat + 2 * numtrainingcases; x++)
            {
                int[] query = CalcInputs(x);
                int answer = tree.Decide(query); // makes the prediction
                Assert.AreEqual(CalcY(x), answer); // check the answer is what we expected - ie the tree got it right
                Console.WriteLine("Prediction \t\t " + x+"\t "+answer);
            }
        }
