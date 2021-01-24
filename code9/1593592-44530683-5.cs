    private const string lineSeparator = new string('-', 90);
    public void Chromosomes(IEnumerable<int[,]> population, int round)
    {  
        ////////////////  print  each chromosome matrix ////////////////
        using (writer = new StreamWriter("C:/Users/Welcome/Desktop/listOfChromosomesForAllRounds.txt", true))
        {
            writer.WriteLine("{0}\n********************************* List of Chrmomsomes (Round : {1})**********************************\n{2}", lineSeparator, round, lineSeparator);
    
            foreach (int[,] chromosme in population)
            {
                for (int h = 0; h < chromosme.GetLength(0); h++)
                {
                    for (int k = 0; k < chromosme.GetLength(1); k++)
                    {
                        writer.Write("|{0}|", chromosme[h, k]);
                    }
                    writer.WriteLine();
                }
                writer.WriteLine(lineSeparator);
            }
        }
    }
