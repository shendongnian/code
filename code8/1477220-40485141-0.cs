                string[] inputs = { "1000.12", "1,000.12", "1.000.12", "1,000,12", "1000,,12", "1000.12" };
                for (int i = 0; i < inputs.Count(); i++)
                {
                    inputs[i] = inputs[i].Replace(".", "");
                    inputs[i] = inputs[i].Replace(",", "");
                    string output = inputs[i].Substring(0, inputs[i].Length - 2) + "," + inputs[i].Substring(inputs[i].Length - 1);
                    Console.WriteLine(output);
                }
                Console.ReadLine();
