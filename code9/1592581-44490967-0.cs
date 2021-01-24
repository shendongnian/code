            int someNumberOfRow = 10;//This is just for testing purposes.
            Random random = new Random();//This is just for testing purposes.
            List<List<int>> myList = new List<List<int>>();
            
            //add two elements to the an arraylist<int> then add this arraylist to myList arraylist
            for(int i = 0; i < someNumberOfRow; i++)
            {
                //Create inner list and add two ints to it.
                List<int> innerList = new List<int>();
                innerList.Add(random.Next());
                innerList.Add(random.Next());
                //Add the inner list to myList;
                myList.Add(innerList);
            }
            //This prints myList
            for(int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + myList[i][0] + " - " + myList[i][1]);
            }
            Console.WriteLine("\n\n");
            //If the app may scale in the future, I suggest you use an approach similar to this
            foreach(List<int> sublist in myList)
            {
                foreach(int columns in sublist)
                {
                    Console.Write(columns + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
