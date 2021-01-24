    CancellationTokenSource cancelSource = new CancellationTokenSource();
    public void Cancel() {
        cancelSource.Cancel();
    }
    public async Task Genetic_Algorithm(List<int[,]> population) {
        cancelSource = new CancellationTokenSource();
        DateTime startT = DateTime.Now.Date;
        double[,] FitnessValue = new double[6, 2]; // for all five chromosome we store two Values the Fitness Value and the Fitness Ratio
        int[] RouletteWheel = new int[6];
        int round = 0;
        for (geneticIteration = 0; geneticIteration < 50; geneticIteration++) {
            round = geneticIteration + 1;
            // Calculate the fitness Function and the Fitness Ratio
            await FitnessFunction(population); // Fitness Function
        }
        MessageBox.Show("Press Again");
    } 
    public Task FitnessFunction(List<int[,]> population) {
        extractPath(population, geneticIteration);
        
        var task0 = RunAuv0GeneticAsync(cancelSource.Token); // start obj # 1
        var task1 = RunAuv1GeneticAsync(cancelSource.Token); // start obj # 2
        var task2 = RunAuv2GeneticAsync(cancelSource.Token); // start obj # 3
        var task3 = RunAuv3GeneticAsync(cancelSource.Token); // start obj # 4
        return Task.WhenAll(task0, task1, task2, task3);
    }
