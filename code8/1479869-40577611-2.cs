        // this is the sequence y follows
        int[] ysequence = new int[] { 1, 2, 3, 2 };
        // this generates the correct Y for a given X
        int CalcY(int x) => ysequence[(x - 1) % 4];
        // this generates some inputs - just a few differnt mod of x
        int[] CalcInputs(int x) => new int[] { x % 2, x % 3, x % 4, x % 5, x % 6 };
        // for http://stackoverflow.com/questions/40573388/simple-accord-net-machine-learning-example
        [TestMethod]
        public void AccordID3TestStackOverFlowQuestion2()
        {
            // build the training data set
            int numtrainingcases = 12;
            int[][] inputs = new int[numtrainingcases][];
            int[] outputs = new int[numtrainingcases];
            Console.WriteLine("\t\t\t\t x \t y");
            for (int x = 1; x <= numtrainingcases; x++)
            {
                int y = CalcY(x);
                inputs[x-1] = CalcInputs(x);
                outputs[x-1] = y;
                Console.WriteLine("TrainingData \t " +x+"\t "+y);
            }
            // define how many values each input can have
            DecisionVariable[] attributes =
            {
                new DecisionVariable("Mod2",2),
                new DecisionVariable("Mod3",3),
                new DecisionVariable("Mod4",4),
                new DecisionVariable("Mod5",5),
                new DecisionVariable("Mod6",6)
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
            for (int x = numtrainingcases+1; x <= 2* numtrainingcases; x++)
            {
                int[] query = CalcInputs(x);
                int answer = tree.Decide(query); // makes the prediction
                Assert.AreEqual(CalcY(x), answer); // check the answer is what we expected - ie the tree got it right
                Console.WriteLine("Prediction \t\t " + x+"\t "+answer);
            }
        }
