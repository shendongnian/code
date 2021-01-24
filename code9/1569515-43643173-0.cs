    public static List<int> Search(int[] studentGrade, int userInput, ref int counter)
        {
            var listOfSubscripts = new List<int>();
            counter = 0;
    
            for (int s = 0; s < studentGrade.Length; s++)
            {
                counter++;                             
    
                if (studentGrade[s] == userInput)
                    listOfSubscripts.Add(s);
            }
            return listOfSubscripts;
        }
