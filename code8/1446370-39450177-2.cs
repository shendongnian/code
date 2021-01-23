    int test = Convert.ToInt32(Console.ReadLine());
    int[,] nutjob = new int[2, 3];
    for(int i = 0; i < 3; i++ )
    {    
        string[] values = Console.ReadLine().Split();
        for(int o = 0; o < 2; o++)
        {
            nutjob[o, i] = int.Parse(values[o]);   
        }
    }
    /* 
    * Input like:
    * 3 4
    * 5 7
    * 2 6
    */
