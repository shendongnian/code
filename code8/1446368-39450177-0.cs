    int test = Convert.ToInt32(Console.ReadLine());
    int[,] nutjob = new int[2, 3];
    string[] values = Console.ReadLine().Split();
    for(int i = 0; i < 3; i++ )
    {    
        for(int o = 0; o < 2; o++)
         {
             nutjob[o, i] = int.Parse(values[i * 2 + o]);   
         }
    }
