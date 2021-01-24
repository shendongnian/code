    int[] input = new int[20]();
    
    //Fill array
    for(int i = 0; i < numbers.lenght; i++)
      input[i] = i;
      
    //initialise the real work variables
    List<int> Drawables = new List<int>(input);
    List<int> DrawnNumbers = new List<int>();
    Random rng = new Random();
    
    while(Drawables.Count > 0){
      int temp = Random.NextInt(Drawables.Count);
      DrawnNumbers = Drawables[i];
      Drawables.Remove(temp);
    }
