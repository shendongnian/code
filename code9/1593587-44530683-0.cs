    static List<int[,]> PopulationChromosomes = new List<int[,]>();
    #region AUV Genetic Movement
    private Random rnd = new Random(); // to generate random number (either 0 or 1)
    private void moveGenetic_Click(object sender, EventArgs e)
    {               
        using (StreamWriter sw = new StreamWriter(new FileStream("C:/Users/Welcome/Desktop/intialPopulation.txt", FileMode.Append, FileAccess.Write)))   
        {   
            var population = new int[6][,]; // define this in the scope where you use it
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = new int[5, 5];
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        population[i][j, k] = rnd.Next(0, 2);
                        sw.Write("|{0}|", population[i][j, k]);
                    } // end-inner-for
                    sw.WriteLine();
                } // end-outer-inner-for
                PopulationChromosomes.Add(population[i]);
            } // end-outer-for
        } // end-using    
    
        Chromosomes(PopulationChromosomes, 1);
    }
