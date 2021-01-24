            int data = 0;
            List<string> tempOutputFileList = new List<string>();
            while (inputLines[data] != "0")
            {
                var listOfPeople = new List<float>();
                int people = int.Parse(inputLines[data++]);
                for (int n = 0; n < people; n++)
                {
                    int receipts = int.Parse(inputLines[data++]);
                    float tempPeople = 0;
                    for (int p = 0; p < receipts; p++)
                    {
                        tempPeople += float.Parse(inputLines[data++]);
                    }
                    listOfPeople.Add(tempPeople);
                }
                foreach (float item in listOfPeople)
                {
                    Console.WriteLine(listOfPeople.Average() - item);
                }
            }
            Console.ReadLine();
