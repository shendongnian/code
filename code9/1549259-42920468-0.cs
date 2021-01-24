    static void Main()
        {
            List<int> listOfInts = new List<int>();
            List<bool> listOfBools = new List<bool>();
            listOfInts.Add(1);
            listOfInts.Add(2);
            listOfInts.Add(1);
            listOfBools.Add(false);
            listOfBools.Add(false);
            listOfBools.Add(false);
            Console.WriteLine("value = " + Compare(listOfInts,listOfBools));
        }
